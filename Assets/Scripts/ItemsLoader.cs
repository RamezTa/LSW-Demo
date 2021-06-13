using UnityEngine;
using System.Collections.Generic;

public class ItemsLoader : MonoBehaviour
{
    static Dictionary<int, ItemScriptableObject> itemsDic = new Dictionary<int, ItemScriptableObject>();
    static Dictionary<int, OutfitScriptableObject> outfitsDic = new Dictionary<int, OutfitScriptableObject>();


    public static ItemScriptableObject GetItem( int id )
    {   // if first call
        if( itemsDic.Count == 0 )
            LoadAllItems();

        if ( itemsDic.ContainsKey( id ) )
        {
            return itemsDic[id];
        }
        else
        {
            Debug.LogError("No Item Found with the ID: " + id);
            return null;
        }
    }
    public static OutfitScriptableObject GetOutfit( int id )
    {   // if first call
        if( outfitsDic.Count == 0 )
            LoadAllItems();

        if ( outfitsDic.ContainsKey( id ) )
        {
            return outfitsDic[id];
        }
        else
        {
            Debug.LogError("No Outfit Found with the ID: " + id);
            return null;
        }
    }

    
    public static ItemTypeSO GetTypeOf( int id )
    {
        // if first call
        if( itemsDic.Count == 0 )
            LoadAllItems();

        if( itemsDic.ContainsKey( id ) )
        {
            return itemsDic[id].type;
        }
        else if ( outfitsDic.ContainsKey( id ) )
        {
            return outfitsDic[id].type;
        }
        else
        {
            Debug.LogError("No Item Found with the ID: " + id);
            return ItemTypeSO.None;
        }
    }
    public static Sprite GetIconOf( int id )
    {
        // if first call
        if( itemsDic.Count == 0 )
            LoadAllItems();

        if( itemsDic.ContainsKey( id ) )
        {
            return itemsDic[id].icon;
        }
        else if ( outfitsDic.ContainsKey( id ) )
        {
            return outfitsDic[id].icon;
        }
        else
        {
            Debug.LogError("No Item Found with the ID: " + id);
            return null;
        }
    }
    public static string GetNameOf( int id )
    {
        // if first call
        if( itemsDic.Count == 0 )
            LoadAllItems();

        if( itemsDic.ContainsKey( id ) )
        {
            return itemsDic[id].name;
        }
        else if ( outfitsDic.ContainsKey( id ) )
        {
            return outfitsDic[id].name;
        }
        else
        {
            Debug.LogError("No Item Found with the ID: " + id);
            return "";
        }
    }
    public static int GetPriceOf( int id )
    {
        // if first call
        if( itemsDic.Count == 0 )
            LoadAllItems();

        if( itemsDic.ContainsKey( id ) )
        {
            return itemsDic[id].price;
        }
        else if ( outfitsDic.ContainsKey( id ) )
        {
            return outfitsDic[id].price;
        }
        else
        {
            Debug.LogError("No Item Found with the ID: " + id);
            return 0;
        }
    }

    
    static void LoadAllItems()
    {
        List<ItemScriptableObject> items = new List<ItemScriptableObject>();
        items.AddRange( Resources.LoadAll<ItemScriptableObject> ( "Items/Hats" ) );
        items.AddRange( Resources.LoadAll<ItemScriptableObject> ( "Items/Shields" ) );
        items.AddRange( Resources.LoadAll<ItemScriptableObject> ( "Items/Weapons" ) );
        
        List<OutfitScriptableObject> outfits = new List<OutfitScriptableObject>();
        outfits.AddRange( Resources.LoadAll<OutfitScriptableObject> ( "Items/Outfits" ) );
        
        // list items to get by id from dictionary
        foreach( ItemScriptableObject item in items )
        {
            if ( ! itemsDic.ContainsKey( item.id ) )
            {
                itemsDic.Add( item.id, item );
            }
            else
            {
                Debug.LogError("Item Name: " + itemsDic[item.id].name + " - ID: " + itemsDic[item.id].id + "  Had the same ID with: " + item.name );
            }
        }

        foreach( OutfitScriptableObject item in outfits )
        {
            if ( ! outfitsDic.ContainsKey( item.id ) )
            {
                outfitsDic.Add( item.id, item );
            }
            else
            {
                Debug.LogError("Outfit Name: " + outfitsDic[item.id].name + " - ID: " + outfitsDic[item.id].id + "  Had the same ID with: " + item.name );
            }
        }

        // make sure items and outfits don't have the same id too
        foreach( ItemScriptableObject item in items )
        {
            if( outfitsDic.ContainsKey( item.id ) )
            {
                Debug.LogError("Outfit Name: " + outfitsDic[item.id].name + " - ID: " + outfitsDic[item.id].id + "  Had the same ID with: " + item.name );
            }
        }

    }

}
