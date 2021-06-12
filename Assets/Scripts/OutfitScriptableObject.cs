using UnityEngine;

[CreateAssetMenu(fileName = "OutfitData", menuName = "ScriptableObjects/New Outfit", order = 1)]
public class OutfitScriptableObject : ScriptableObject
{
    public string name;
    public int price;
    public ItemTypeSO type;

    public Sprite vest;
    public Sprite boots;
    public Sprite pauldrons;
    public Sprite gloves;
}