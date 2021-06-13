using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] ShopPanel shopPanel;
    [SerializeField] InventoryBage inventory;

    public void ActivateShop()
    {
        shopPanel.ShowShop( inventory );
    }

}
