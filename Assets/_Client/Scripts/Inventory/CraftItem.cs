using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/CraftItem", fileName = "New Craft")]
public class CraftItem : ScriptableObject
{
    [SerializeField] private List<InventoryItemSO> _components;
    [SerializeField] private InventoryItemSO _itemAustCraft;

    public List<InventoryItemSO> GetComponents() => _components;
    public InventoryItemSO GetItemSOAustCraftItem() => _itemAustCraft;
}
