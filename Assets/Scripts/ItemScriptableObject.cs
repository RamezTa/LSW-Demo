using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/New Item", order = 1)]
public class ItemScriptableObject : ScriptableObject, IItem
{
    public string itemName;
    public int price;
    public ItemTypeSO type;
    public Sprite sprite;

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
        return sprite;
    }
    public ItemTypeSO GetType ()
    {
        return type;
    }
}