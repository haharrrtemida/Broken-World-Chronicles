using Artemida.Tools;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : PersistentSingleton<InventoryManager>
{
    [SerializeField] private List<InventoryItemSO> _inventoryItems;
    //public event 

    public void Initialize()
    {
        _inventoryItems = new List<InventoryItemSO>();
    }

    public void AddItem(InventoryItemSO Item)
    {
        _inventoryItems.Add(Item);
    }

    public void RemoveItem(InventoryItemSO Item)
    {
        _inventoryItems.Add(Item);
    }

    public void CloseInventory()
    {
        ScenesManager.Instance.CloseInventory();
    }
}
