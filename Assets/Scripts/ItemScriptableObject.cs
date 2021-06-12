using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/New Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public int price;
    public ItemTypeSO type;
    public Sprite sprite;
}