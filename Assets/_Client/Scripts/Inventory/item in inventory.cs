using UnityEngine;
using UnityEngine.UI;

public class itemininventory : MonoBehaviour
{
    [SerializeField] private Button _aboutButton;
    private InventoryItemSO _item;
    private itemininventory _curentItem; 

    public delegate void OnItemClickedDelegate(InventoryItemSO item);
    public event OnItemClickedDelegate OnItemClicked;

    private void Start()
    {
        _curentItem = GetComponent<itemininventory>();
        _aboutButton.onClick.AddListener(ActiveItem);
    }

    public void NewItem(InventoryItemSO item)
    {
        _item = item;
    }

    private void ActiveItem()
    {
        OnItemClicked?.Invoke(_item);
    }
}
