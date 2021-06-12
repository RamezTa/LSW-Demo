using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterCustomization ) )]
public class PlayerInventory : MonoBehaviour
{
    CharacterCustomization characterCustomization;
    [SerializeField] InventoryPanel inventoryPanel;
    bool inventoryShown;

    [Header("Equipped")]
    public OutfitScriptableObject currentOutfit;
    public ItemScriptableObject currentHelmet;
    public ItemScriptableObject currentWeapon;
    public ItemScriptableObject currentShield;

    [Space]
    
    [Header("Default")]
    
    public OutfitScriptableObject defaultOutfit;
    public ItemScriptableObject defaultHelmet;
    public ItemScriptableObject defaultWeapon;
    public ItemScriptableObject defaultShield;

    [Space]

    [Header("In Inventory")]
    public List<OutfitScriptableObject> inventoryOutfits;
    public List<ItemScriptableObject> inventoryItems;
    

    void Awake()
    {
        characterCustomization = GetComponent<CharacterCustomization>();
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.I) )
        {
            inventoryPanel.ShowInventory( ! inventoryShown );
            
            inventoryShown = ! inventoryShown;
        }
    }


    public void Equip( int itemID )
    {
        ItemTypeSO itemType = ItemsLoader.GetTypeOf( itemID );

        if( ItemsLoader.GetTypeOf( itemID ) == ItemTypeSO.Outfit )
        {
            OutfitScriptableObject outfit = ItemsLoader.GetOutfit( itemID );

            inventoryOutfits.Remove(outfit);             // remove the outfit from inventory to current 
            if( currentOutfit.id != 6 )                  // 6 is the DefaultRobe don't store it into the inventory
                inventoryOutfits.Add(currentOutfit);        // store the currentOufit back to inventory if 

            currentOutfit = outfit;

            inventoryPanel.SetEquiptedOutfit( itemID );
            characterCustomization.ChangeOutfit ( outfit );
        }
        else
        {   
            ItemScriptableObject item = ItemsLoader.GetItem( itemID );
            inventoryItems.Remove ( item );

            switch( itemType )
            {
                case ItemTypeSO.Shield:
                    if( currentShield.sprite != null )                  // make sure the item is not default shield
                        inventoryItems.Add ( currentShield );

                    currentShield = item;                               // switch

                    inventoryPanel.SetEquiptedSheild( itemID );
                    characterCustomization.ChangeSheild( item );
                    break;

                case ItemTypeSO.Weapon:     
                    if( currentWeapon.sprite != null )
                        inventoryItems.Add ( currentWeapon );

                    currentWeapon = item;

                    inventoryPanel.SetEquiptedWeapon( itemID );
                    characterCustomization.ChangeWeapon( item );    
                    break;

                case ItemTypeSO.Hat:
                    if( currentHelmet.sprite != null )
                        inventoryItems.Add ( currentHelmet );

                    currentHelmet = item;

                    inventoryPanel.SetEquiptedHelmet( itemID );
                    characterCustomization.ChangeHat( item );
                    break;
                
                default:
                    Debug.LogError("No characterCustomization for ItemType: " + itemType);
                    break;
            }
        }
    }


    public void Remove( ItemTypeSO itemType ) 
    {
        switch( itemType )
        {
            case ItemTypeSO.Outfit:
                inventoryOutfits.Add( currentOutfit );
                currentOutfit = defaultOutfit;
                characterCustomization.ChangeOutfit( currentOutfit );
                inventoryPanel.SetEquiptedOutfit( currentOutfit.id );
                break;

            case ItemTypeSO.Shield:
                inventoryItems.Add( currentShield );
                currentShield = defaultShield;
                characterCustomization.ChangeSheild( currentShield );
                inventoryPanel.SetEquiptedSheild( currentShield.id );
                break;

            case ItemTypeSO.Weapon:
                inventoryItems.Add( currentWeapon );
                currentWeapon = defaultWeapon;
                characterCustomization.ChangeWeapon( currentWeapon );
                inventoryPanel.SetEquiptedWeapon( currentWeapon.id );
                break;

            case ItemTypeSO.Hat:
                inventoryItems.Add( currentHelmet );
                currentHelmet = defaultHelmet;
                characterCustomization.ChangeHat( currentHelmet );
                inventoryPanel.SetEquiptedHelmet( currentHelmet.id );
                break;
        }
    }


    public List<int> GetAllItemsIDs ()
    {
        List<int> ids = new List<int>();

        foreach( ItemScriptableObject item in inventoryItems )
        {
            ids.Add( item.id );
        }

        foreach( OutfitScriptableObject outfit in inventoryOutfits )
        {
            ids.Add( outfit.id );
        }

        return ids;
    }

}
