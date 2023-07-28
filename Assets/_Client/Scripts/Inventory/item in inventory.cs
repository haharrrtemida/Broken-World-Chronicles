using UnityEngine;
using UnityEngine.UI;

public class itemininventory : MonoBehaviour
{
    [SerializeField] private Button _aboutButton;
    private InventoryItemSO _item;

    public delegate void OnItemClickedDelegate(InventoryItemSO item);
    public event OnItemClickedDelegate OnItemClicked;

    private void Start()
    {
        _aboutButton.onClick.AddListener(ShowPanelAbout);
    }

    public void NewItem(InventoryItemSO item)
    {
        _item = item;
    }

    private void ShowPanelAbout()
    {
        OnItemClicked?.Invoke(_item);
    }
}
