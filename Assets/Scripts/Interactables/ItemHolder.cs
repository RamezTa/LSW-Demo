using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;

    [SerializeField] List<OutfitScriptableObject> outfits;
    [SerializeField] List<ItemScriptableObject> items;
    [SerializeField] int gold;
    

    public void AddHolded()
    {
        if( gold != 0 )
        {
            playerInventory.AddGold( gold );
        }

        if( outfits.Count != 0 )
        {
            foreach( OutfitScriptableObject outfit in outfits )
            {
                playerInventory.AddItem( outfit.id );
            }
        }

        if( items.Count != 0 )
        {
            foreach( ItemScriptableObject item in items )
            {
                playerInventory.AddItem( item.id );
            }
        }
    }

}
