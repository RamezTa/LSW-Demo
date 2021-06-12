using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    [SerializeField] Image icon;
    [SerializeField] Sprite defultIcon;
    
    [SerializeField] Text count;


    [SerializeField] GameObject selectedFram;
    [SerializeField] bool isSelected;

    [Space]

    [SerializeField] ItemScriptableObject itemSO;

    


}
