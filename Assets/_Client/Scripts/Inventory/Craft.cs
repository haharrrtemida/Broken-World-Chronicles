using System.Collections.Generic;
using UnityEngine;

public class Craft : InventoryInterface
{
    protected List<InventoryItemSO> activeItems;
    private string craftItemsNames;
    [SerializeField] private CraftItem[] craftItems;

    protected override void ShowInfoPanel(InventoryItemSO item)
    {
        activeItems.Add(item);
        //_imagePanel.(Color.red); change image
        for (int i = 0; i > activeItems.Count; i++)
        {
            craftItemsNames = craftItemsNames + activeItems[i].GetSprite().ToString() + "+";
        }
        _itemNamePanel.text = craftItemsNames;
        _itemDescriptionPanel.text = "none";
    }
    protected void CraftLogik()
    {
        for (int i = 0; i > activeItems.Count; i++)
        {
            CraftItem item = craftItems[i];
            if (activeItems == item.GetIngridients())
            {
                InventoryManager.Instance.AddItem(item.GetItemSOAustCraftItem());
                for (int a = 0; a > activeItems.Count; a++)
                {
                    InventoryManager.Instance.RemoveItem(activeItems[a]);
                }
            }
        }
    }
}
