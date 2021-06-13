using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof(CanvasGroup) )]
public class ShopPanel : MonoBehaviour
{
    public static bool IsOpen;
    CanvasGroup canvasGroup;

    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] InventoryBage shopkeeperInventory;


    [Space]


    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] InventoryItem selectedItem;

    [Header("Shopkeeper Itmes")]
    [SerializeField] Transform shopkeeperItemsHolder;
    [SerializeField] List<InventoryItem> shopkeeperInventoryItems;

    [Header("Player Itmes")]
    [SerializeField] Transform playerItemsHolder;
    [SerializeField] List<InventoryItem> playerInventoryItems;


    [Space]

    [Header("Item Info")]
    [SerializeField] Image itemInfoImage;
    [SerializeField] Sprite itemInfoDefaultSprite;
    [SerializeField] Text playerGold;
    [SerializeField] Text NotEnoughGold;
    [SerializeField] Text itemInfoName;
    [SerializeField] Text itemInfoPrice;
    [SerializeField] Text itemInfoType;

    [Space]

    [Header("Buttons")]

    [SerializeField] Button SellButton;
    [SerializeField] Button BuyButton;

    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowShop( InventoryBage shopkeeperInv )
    {
        IsOpen = true;

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        shopkeeperInventory = shopkeeperInv;

        playerGold.text = playerInventory.GetPlayerGold().ToString();
        UpdatePlayerInventoryItems();
        UpdateShopkeeperInventoryItems();
    }
    public void HideShop()
    {
        IsOpen = false;

        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        if ( selectedItem != null )
            selectedItem.SetSelected( false );

        selectedItem = null;
    }
    

    void UpdatePlayerInventoryItems()
    {
        List<int> itemsIDs = playerInventory.inventory.GetAllItemsIDs();

        // match inventoryItems number to player inventory items number
        if ( itemsIDs.Count == 0 )                       // if inventory empty, remove all inventoryItems
        {
            for( int x = 0; x < playerInventoryItems.Count; x++ )
            {
                Destroy( playerInventoryItems[x].gameObject );
            }

            playerInventoryItems.Clear();
        }
        else if( itemsIDs.Count > playerInventoryItems.Count )          // needs more inventory items
        {
            int delta =  itemsIDs.Count - playerInventoryItems.Count;
            for( int x = 0; x < delta; x++ )
            {
                GameObject itemObj = Instantiate( inventoryItemPrefab, playerItemsHolder );
                InventoryItem item = itemObj.GetComponent<InventoryItem>();
                item.button.onClick.AddListener( delegate{ SetSelectItem( item ); } );
                item.button.onClick.AddListener( delegate{ ShowSellButton(); } );
                playerInventoryItems.Add( item );
            }
        }
        else if( itemsIDs.Count < playerInventoryItems.Count )     // too many inventory items
        {
            int delta = playerInventoryItems.Count - itemsIDs.Count;
            for( int x = 0; x < delta; x++ )
            {
                InventoryItem item = playerInventoryItems[x];
                playerInventoryItems.Remove( item );
                Destroy( item.gameObject );
            }
        }   

        for( int x = 0; x < playerInventoryItems.Count; x++ )
        {
            playerInventoryItems[x].SetItem( itemsIDs[x], true );
        }
    }
    void UpdateShopkeeperInventoryItems()
    {
        List<int> itemsIDs = shopkeeperInventory.GetAllItemsIDs();

        // match inventoryItems number to player inventory items number
        if ( itemsIDs.Count == 0 )                       // if inventory empty
        {
            for( int x = 0; x < shopkeeperInventoryItems.Count; x++ )
            {
                Destroy( shopkeeperInventoryItems[x].gameObject );
            }

            shopkeeperInventoryItems.Clear();
        }
        else if( itemsIDs.Count > shopkeeperInventoryItems.Count )          // needs more inventory items
        {
            int delta =  itemsIDs.Count - shopkeeperInventoryItems.Count;
            for( int x = 0; x < delta; x++ )
            {
                GameObject itemObj = Instantiate( inventoryItemPrefab, shopkeeperItemsHolder );
                InventoryItem item = itemObj.GetComponent<InventoryItem>();
                item.button.onClick.AddListener( delegate{ SetSelectItem( item ); } );
                item.button.onClick.AddListener( delegate{ ShowBuyButton(); } );
                shopkeeperInventoryItems.Add( item );
            }
        }
        else if( itemsIDs.Count < shopkeeperInventoryItems.Count )     // too many inventory items
        {
            int delta = shopkeeperInventoryItems.Count - itemsIDs.Count;
            for( int x = 0; x < delta; x++ )
            {
                InventoryItem item = shopkeeperInventoryItems[x];
                shopkeeperInventoryItems.Remove( item );
                Destroy( item.gameObject );
            }
        }   
        

        for( int x = 0; x < shopkeeperInventoryItems.Count; x++ )
        {
            shopkeeperInventoryItems[x].SetItem( itemsIDs[x], true );
        }
    }


    public void SetSelectItem( InventoryItem item )
    {
        if ( selectedItem != null )
            selectedItem.SetSelected( false );

        selectedItem = item;
        selectedItem.SetSelected( true );

        itemInfoImage.sprite = ItemsLoader.GetIconOf( item.itemID );
        
        itemInfoPrice.gameObject.SetActive(true);
        itemInfoPrice.text = "Price: " + ItemsLoader.GetPriceOf ( item.itemID ).ToString();

        itemInfoName.text = ItemsLoader.GetNameOf( item.itemID );
        itemInfoType.text = ItemsLoader.GetTypeOf( item.itemID ).ToString();
    }
    void ResetInfoPanel()
    {
        itemInfoImage.sprite = itemInfoDefaultSprite;
        // hide price if no item is selected
        itemInfoPrice.gameObject.SetActive(false);
        itemInfoPrice.text = "";

        itemInfoName.text = "";
        itemInfoType.text = "";
    }

    
    public void SellSelected()
    {
        shopkeeperInventory.AddItem( selectedItem.itemID );
        playerInventory.inventory.RemoveItem ( selectedItem.itemID );

        playerInventory.AddGold( ItemsLoader.GetPriceOf( selectedItem.itemID ) );
        playerGold.text = playerInventory.GetPlayerGold().ToString();

        UpdatePlayerInventoryItems();
        UpdateShopkeeperInventoryItems();

        ResetInfoPanel();
        
        selectedItem.SetSelected(false);
        selectedItem = null;
    }
    public void BuySelected()
    {
        int itemPirce = ItemsLoader.GetPriceOf( selectedItem.itemID );

        if( ! playerInventory.CanAfford( itemPirce ) )
        {
            StopAllCoroutines();               // stop if counint in case buy button was prcessed too many times
            StartCoroutine( ShowNoEnoughGold( 2 ) );
            return;
        }

        shopkeeperInventory.RemoveItem( selectedItem.itemID );
        playerInventory.inventory.AddItem( selectedItem.itemID );

        playerInventory.PayGold( itemPirce );
        playerGold.text = playerInventory.GetPlayerGold().ToString();

        UpdatePlayerInventoryItems();
        UpdateShopkeeperInventoryItems();

        ResetInfoPanel();

        selectedItem.SetSelected(false);
        selectedItem = null;
    }
    IEnumerator ShowNoEnoughGold( float amount )
    {
        NotEnoughGold.gameObject.SetActive(true);
        yield return new WaitForSeconds( amount );
        NotEnoughGold.gameObject.SetActive(false);
    }


    public void ShowSellButton()
    {
        SellButton.gameObject.SetActive(true);
        BuyButton.gameObject.SetActive(false);
    }
    public void ShowBuyButton()
    {
        SellButton.gameObject.SetActive(false);
        BuyButton.gameObject.SetActive(true);
    }
    
}

