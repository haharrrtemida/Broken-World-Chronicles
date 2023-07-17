using Artemida.Tools;
using System.Collections.Generic;

public class InventoryManager : PersistentSingleton<InventoryManager>
{
    private List<InventoryItemSO> _inventoryItems;
    private List<InventoryItemSO> _removeList;
    //public event 

    public void Initialize()
    {
        _inventoryItems = new List<InventoryItemSO>();
        _removeList = new List<InventoryItemSO>();
    }

    public List<InventoryItemSO> GetList() => _inventoryItems;
    public List<InventoryItemSO> GetRemoveList() => _removeList;
    public void ResetRemoveList()
    {
        _removeList.Clear();    
    }

    public void AddItem(InventoryItemSO Item)
    {
        _inventoryItems.Add(Item);
    }

    public void RemoveItem(InventoryItemSO Item)
    {
        _inventoryItems.Remove(Item);
        _removeList.Add(Item);
    }

    public void CloseInventory()
    {
        ScenesManager.Instance.CloseInventory();
        Player.Instance.AddRemoveItem();
    }
}
