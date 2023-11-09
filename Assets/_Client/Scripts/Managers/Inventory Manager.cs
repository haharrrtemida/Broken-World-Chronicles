using Artemida.Tools;
using System.Collections.Generic;

public class InventoryManager : PersistentSingleton<InventoryManager>
{
    private List<InventoryItemSO> _inventoryItems;
    private InventoryMode _mode;

    public void Initialize()
    {
        _inventoryItems = new List<InventoryItemSO>();
    }
    public InventoryMode GetInventoryMode() => _mode;
    public void ChangeModeInventory(InventoryMode mode)
    {
        _mode = mode;
    }

    public List<InventoryItemSO> GetList() => _inventoryItems;

    public void AddItem(InventoryItemSO Item)
    {
        _inventoryItems.Add(Item);
    }

    public void RemoveItem(InventoryItemSO Item)
    {
        _inventoryItems.Remove(Item);
    }
}
