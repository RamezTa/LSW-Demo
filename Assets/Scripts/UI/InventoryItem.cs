using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public int itemID;
    public Button button;

    [SerializeField] Image icon;

    [SerializeField] Sprite defaultIcon;
    [SerializeField] Color defaultIconColor;
    [SerializeField] Color ShownColor;
    
    [SerializeField] Text count;


    [SerializeField] GameObject selectedFram;
    [SerializeField] bool isSelected;

    
    public void SetSelected( bool x )
    {
        selectedFram.SetActive(x);
    }

    public void SetItem( int itemId, bool showPirce = false, int pirce = 0 )
    {
        itemID = itemId;

        Sprite iconSprite = ItemsLoader.GetIconOf( itemID );

        // defaut weapon / sheild / helmet are empty
        if( iconSprite == null )
        {
            icon.sprite = defaultIcon;
            icon.color = defaultIconColor;
        }
        else
        {
            icon.sprite = iconSprite;
            icon.color = ShownColor;
        }

        count.gameObject.SetActive( showPirce );
        count.text = pirce.ToString();
    }



}
