using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    //Customization ScriptableObject
    public List<OutfitScriptableObject> Outfits = new List<OutfitScriptableObject>();
    public List<ItemScriptableObject> hats = new List<ItemScriptableObject>();
    public List<ItemScriptableObject> shields = new List<ItemScriptableObject>();
    public List<ItemScriptableObject> weapons = new List<ItemScriptableObject>();


    //Outfit Sprites
    public SpriteRenderer armL;
    public SpriteRenderer armR;
    public SpriteRenderer finger;
    public SpriteRenderer forearmL;
    public SpriteRenderer forearmR;
    public SpriteRenderer handL;
    public SpriteRenderer handR;
    public SpriteRenderer legL;
    public SpriteRenderer legR;
    public SpriteRenderer plevis;
    public SpriteRenderer shinL;
    public SpriteRenderer shinR;
    public SpriteRenderer sleeveR;
    public SpriteRenderer trose;

    //Other Sprite
    public SpriteRenderer hat;
    public SpriteRenderer shield;
    public SpriteRenderer weapon;
    public SpriteRenderer hair;


    public void ChangeOutfit(OutfitScriptableObject outfit)
    {
        armL.sprite = outfit.armL;
        armR.sprite = outfit.armR;
        finger.sprite = outfit.armL;
        forearmL.sprite = outfit.forearmL;
        forearmR.sprite = outfit.forearmR;
        handL.sprite = outfit.handL;
        handR.sprite = outfit.handR;
        legL.sprite = outfit.leg;
        legR.sprite = outfit.leg;
        plevis.sprite = outfit.plevis;
        shinL.sprite = outfit.shin;
        shinR.sprite = outfit.shin;
        sleeveR.sprite = outfit.sleeveR;
        trose.sprite = outfit.trose;
    }

    public void ChangeHat(ItemScriptableObject hatItem)
    {
        hat.sprite = hatItem.sprite;

        if (hat.sprite == null)
            hair.enabled = true;
        else
            hair.enabled = false;
    }

    public void ChangeSheild(ItemScriptableObject shieldItem)
    {
        shield.sprite = shieldItem.sprite;
    }
    public void ChangeWeapon(ItemScriptableObject weaponItem)
    {
        weapon.sprite = weaponItem.sprite;
    }


}
