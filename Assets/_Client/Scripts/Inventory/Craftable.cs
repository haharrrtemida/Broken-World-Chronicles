using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Craft", menuName = "Craft/New Craft")]
public class CraftItem : ScriptableObject
{
    [SerializeField] private InventoryItemSO _finalItem;
    [SerializeField] private List<InventoryItemSO> _craftResourse;
    public InventoryItemSO GetItemSO() => _finalItem;
    public List<InventoryItemSO> GetResourses() => _craftResourse;
}
