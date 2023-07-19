using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItemSO", fileName = "New Item")]
public class InventoryItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _motherPrefab;

    public Sprite GetSprite() => _icon;
    public string Name() => _name;
    public GameObject GetMotherPrefab() => _motherPrefab;
}
