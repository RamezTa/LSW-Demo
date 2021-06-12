using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    [SerializeField] Image icon;

    [SerializeField] Sprite defaultIcon;
    [SerializeField] Color defaultIconColor;
    [SerializeField] Color ShownColor;
    
    [SerializeField] Text count;


    [SerializeField] GameObject selectedFram;
    [SerializeField] bool isSelected;

    [Space]

    [SerializeField] IItem item;


    public void SetSelected( bool x )
    {
        selectedFram.SetActive(x);
    }

    public void SetItem( IItem i, bool showPirce = false )
    {

    }



}
