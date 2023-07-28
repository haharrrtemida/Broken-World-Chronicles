using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItemSO", fileName = "New Item")]
public class InventoryItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _motherPrefab;
    [SerializeField] private string _About;
    [SerializeField] private string _comment;

    public Sprite GetSprite() => _icon;
    public string Name() => _name;
    public GameObject GetMotherPrefab() => _motherPrefab;
    public string About() => _About;
    public string Comment() => _comment;
}
