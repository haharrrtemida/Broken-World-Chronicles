using Artemida.Tools;
using System.Collections.Generic;

public class InventoryManager : PersistentSingleton<InventoryManager>
{
    private List<InventoryItemSO> _inventoryItems;
    //public event 

    public void Initialize()
    {
        _inventoryItems = new List<InventoryItemSO>();
    }

    public List<InventoryItemSO> GetList() => _inventoryItems;

    public void AddItem(InventoryItemSO Item)
    {
        _inventoryItems.Add(Item);
    }


    public void CloseInventory()
    {
        ScenesManager.Instance.CloseInventory();
    }
}
