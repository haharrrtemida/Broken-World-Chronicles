using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/CraftItem", fileName = "New Craft")]
public class CraftItem : ScriptableObject
{
    [SerializeField] private List<InventoryItemSO> components;
    [SerializeField] private InventoryItemSO _itemAustCraft;

    public List<InventoryItemSO> GetIngridients() => components;
    public InventoryItemSO GetItemSOAustCraftItem() => _itemAustCraft;
}
