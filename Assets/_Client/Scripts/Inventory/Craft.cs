using System.Collections.Generic;
using UnityEngine;

public class Craft : InventoryInterface
{
    private string craftItemsNames;
    [SerializeField] private CraftItem[] craftItems;

    protected override void ShowInfoPanel(InventoryItemSO item)
    {
        if (_mode == InventoryMode.Craft)
        {
            activeItems.Add(item);
            //_imagePanel.(Color.red); change image
            for (int i = 0; i > activeItems.Count; i++)
            {
                craftItemsNames = craftItemsNames + activeItems[i].Name().ToString() + "+";
            }
            _itemNamePanel.text = craftItemsNames;
            _itemDescriptionPanel.text = "none";
            _infoPanel.SetActive(true);
        }
    }
    protected void CraftLogik()
    {
        if (_mode == InventoryMode.Craft)
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
                        print("CRAFTING.....");
                    }
                }
            }
        }
    }

    protected override void CloseInfoPanel() 
    {
        _activeItem = null;
        _infoPanel.SetActive(false);
    }
}
