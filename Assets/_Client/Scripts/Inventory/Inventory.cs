using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : InventoryInterface
{
    protected override void ShowInfoPanel(InventoryItemSO item)
    {
        if (_mode == InventoryMode.Inventory)
        {
            _activeItem = item;
            _imagePanel.sprite = item.GetSprite();
            _itemNamePanel.text = item.Name();
            _itemDescriptionPanel.text = item.About();
            _infoPanel.SetActive(true);
        }
    }

    protected override void CloseInfoPanel()
    {
        _activeItem = null;
        _infoPanel.SetActive(false);
    }
}
