using System.Collections.Generic;

[System.Serializable]
public class InventoryBage 
{
    public List<OutfitScriptableObject> inventoryOutfits = new List<OutfitScriptableObject>();
    public List<ItemScriptableObject> inventoryItems = new List<ItemScriptableObject>();

    public void AddItem ( int itemID )
    {
        if ( ItemsLoader.GetTypeOf( itemID ) == ItemTypeSO.Outfit )
        {
            inventoryOutfits.Add( ItemsLoader.GetOutfit( itemID ) );
        }
        else
        {
            inventoryItems.Add( ItemsLoader.GetItem( itemID ) );
        }
    }
    public void RemoveItem( int itemID )
    {
        if ( ItemsLoader.GetTypeOf( itemID ) == ItemTypeSO.Outfit )
        {
            inventoryOutfits.Remove( ItemsLoader.GetOutfit( itemID ) );
        }
        else
        {
            inventoryItems.Remove( ItemsLoader.GetItem( itemID ) );
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
