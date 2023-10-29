using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/CraftItem", fileName = "New Craft")]
public class CraftItem : ScriptableObject
{
    [SerializeField] private List<InventoryItemSO> ingridients;
    [SerializeField] private InventoryItemSO _itemAustCraft;

    public List<InventoryItemSO> GetIngridients() => ingridients;
    public InventoryItemSO GetItemSOAustCraftItem() => _itemAustCraft;
}
