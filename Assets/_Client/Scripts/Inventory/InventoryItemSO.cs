using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItemSO", fileName = "New Item")]
public class InventoryItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _About;
    [SerializeField] private bool _craftable;

    public Sprite GetSprite() => _icon;
    public string Name() => _name;
    public string About() => _About;
    public bool Craftable => _craftable;
}
