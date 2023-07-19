using UnityEngine;
using Artemida.Tools;

public class itemininventory : MonoBehaviour
{
    private InventoryItemSO _item;

    public void NewItem(InventoryItemSO item)
    {
        _item = item;
    }
    public void Delete()
    {
        InventoryManager.Instance.RemoveItem(_item);
        Destroy(gameObject);
    }
}
