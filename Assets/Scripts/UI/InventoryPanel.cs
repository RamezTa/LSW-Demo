using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent( typeof (CanvasGroup) )]
public class InventoryPanel : MonoBehaviour
{

    public static bool IsOpen;
    CanvasGroup canvasGroup;
    AudioSource audioSource;

    [SerializeField] PlayerInventory playerInventory;
    
    [Space]

    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] Transform inventoryItemsHolder;
    [SerializeField] InventoryItem selectedItem;
    [SerializeField] List<InventoryItem> inventoryItems;

    [Space]

    [Header("Equipped")]

    [SerializeField] InventoryItem Outfit;
    [SerializeField] InventoryItem Helmet;
    [SerializeField] InventoryItem Sheild;
    [SerializeField] InventoryItem Weapon;


    [Space]
    
    [Header("Item Info")]

    [SerializeField] Image itemInfoImage;
    [SerializeField] Sprite itemInfoEmpty;
    [SerializeField] Text itemInfoName;
    [SerializeField] Text itemInfoType;

    [Space]
    
    [Header("Buttons")]

    [SerializeField] GameObject EquipButton;
    [SerializeField] GameObject RemoveButton;


    [Space]

    public AudioClip selectSFX;
    public AudioClip equipSFX;
    public AudioClip unequipSFX;


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();

        Outfit.button.onClick.AddListener( delegate { SetSelectItem( Outfit ); } );
        Helmet.button.onClick.AddListener( delegate { SetSelectItem( Helmet ); } );
        Sheild.button.onClick.AddListener( delegate { SetSelectItem( Sheild ); } );
        Weapon.button.onClick.AddListener( delegate { SetSelectItem( Weapon ); } );
    }

    public void ShowInventory( bool x )
    {
        IsOpen = x;
        
        if( ! x )
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

            if ( selectedItem != null )
                selectedItem.SetSelected( false );

            selectedItem = null;

            return;
        }

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        Outfit.SetItem( playerInventory.currentOutfit.id );
        Helmet.SetItem( playerInventory.currentHelmet.id );
        Sheild.SetItem( playerInventory.currentShield.id );
        Weapon.SetItem( playerInventory.currentWeapon.id );

        UpdateInventoryItems();
    }

    void UpdateInventoryItems()
    {
        List<int> itemsIDs = playerInventory.inventory.GetAllItemsIDs();

        // match inventoryItems number to player inventory items number
        if ( itemsIDs.Count == 0 )                       // if inventory empty
        {
            for( int x = 0; x < inventoryItems.Count; x++ )
            {
                Destroy( inventoryItems[x].gameObject );    
            }

            inventoryItems.Clear();
        }
        else if( itemsIDs.Count > inventoryItems.Count )          // needs more inventory items
        {
            int delta =  itemsIDs.Count - inventoryItems.Count;
            for( int x = 0; x < delta; x++ )
            {
                GameObject itemObj = Instantiate( inventoryItemPrefab, inventoryItemsHolder );
                InventoryItem item = itemObj.GetComponent<InventoryItem>();
                item.button.onClick.AddListener( delegate{ SetSelectItem( item ); } );
                item.button.onClick.AddListener( delegate{ ShowEquipButton(); } );
                inventoryItems.Add( item );
            }
        }
        else if( itemsIDs.Count < inventoryItems.Count )     // too many inventory items
        {
            int delta = inventoryItems.Count - itemsIDs.Count;
            for( int x = 0; x < delta; x++ )
            {
                InventoryItem item = inventoryItems[x];
                inventoryItems.Remove( item );
                Destroy( item.gameObject );
            }
        }

        for( int x = 0; x < inventoryItems.Count; x++ )
        {
            inventoryItems[x].SetItem( itemsIDs[x] );
        }
    }


    public void SetSelectItem( InventoryItem item )
    {
        // EquipButton.SetActive(true);
        // RemoveButton.SetActive(false);

        if ( selectedItem != null)
        {
            selectedItem.SetSelected(false);
        }

        selectedItem = item;
        selectedItem.SetSelected( true );
        audioSource.PlayOneShot(selectSFX);

        itemInfoImage.sprite = ItemsLoader.GetIconOf( item.itemID );
        itemInfoName.text = ItemsLoader.GetNameOf( item.itemID );
        itemInfoType.text = ItemsLoader.GetTypeOf( item.itemID ).ToString();
    }


    public void EquipSelected()
    {
        ItemTypeSO type = ItemsLoader.GetTypeOf( selectedItem.itemID ); 

        playerInventory.Equip( selectedItem.itemID );
        audioSource.PlayOneShot(equipSFX);

        switch( type )
        {
            case ItemTypeSO.Outfit:     Outfit.button.interactable = true;     break;
            case ItemTypeSO.Shield:     Sheild.button.interactable = true;     break;
            case ItemTypeSO.Weapon:     Weapon.button.interactable = true;     break;
            case ItemTypeSO.Hat:        Helmet.button.interactable = true;     break;
        }
        
        UpdateInventoryItems();
        ResetInfoPanel();

        selectedItem.SetSelected( false );
        selectedItem = null;
        EquipButton.SetActive(false);
        RemoveButton.SetActive(false);
    }

    public void RemoveSelected()
    {
        ItemTypeSO type = ItemsLoader.GetTypeOf( selectedItem.itemID ); 

        playerInventory.Remove( type );
        audioSource.PlayOneShot(unequipSFX);


        switch ( type )
        {
            case ItemTypeSO.Outfit:     Outfit.button.interactable = false;     break;
            case ItemTypeSO.Shield:     Sheild.button.interactable = false;     break;
            case ItemTypeSO.Weapon:     Weapon.button.interactable = false;     break;
            case ItemTypeSO.Hat:        Helmet.button.interactable = false;     break;
        }

        ResetInfoPanel();

        UpdateInventoryItems();

        selectedItem.SetSelected( false );
        selectedItem = null;

        EquipButton.SetActive(false);
        RemoveButton.SetActive(false);
    }

    void ResetInfoPanel()
    {
        itemInfoImage.sprite = itemInfoEmpty;
        itemInfoName.text = "";
        itemInfoType.text = "";
    }


    public void ShowEquipButton()
    {
        EquipButton.SetActive(true);
        RemoveButton.SetActive(false);
    }
    public void ShowRemoveButton()
    {
        EquipButton.SetActive(false);
        RemoveButton.SetActive(true);
    }

    
    public void SetEquiptedOutfit( int itemID ) { Outfit.SetItem( itemID ); }
    public void SetEquiptedHelmet( int itemID ) { Helmet.SetItem( itemID ); }
    public void SetEquiptedSheild( int itemID ) { Sheild.SetItem( itemID ); }
    public void SetEquiptedWeapon( int itemID ) { Weapon.SetItem( itemID ); }

}

