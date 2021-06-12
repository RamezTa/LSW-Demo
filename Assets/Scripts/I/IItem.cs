using UnityEngine;

public interface IItem
{
    string GetName ();
    ItemTypeSO GetType ();
    int GetPrice ();
    Sprite GetIcon ();
}