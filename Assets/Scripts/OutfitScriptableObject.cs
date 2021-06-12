using UnityEngine;

[CreateAssetMenu(fileName = "OutfitData", menuName = "ScriptableObjects/New Outfit", order = 1)]
public class OutfitScriptableObject : ScriptableObject, IItem
{
    public string name;
    public int price;
    public ItemTypeSO type;

    public Sprite armL;
    public Sprite armR;
    public Sprite finger;
    public Sprite forearmL;
    public Sprite forearmR;
    public Sprite handL;
    public Sprite handR;
    public Sprite leg;
    public Sprite plevis;
    public Sprite shin;
    public Sprite sleeveR;
    public Sprite trose;


    public string GetName ()
    {
        return name;
    }
    public int GetPrice ()
    {
        return price;
    }
    public Sprite GetIcon ()
    {
        return trose;
    }
    public ItemTypeSO GetType ()
    {
        return type;
    }
}