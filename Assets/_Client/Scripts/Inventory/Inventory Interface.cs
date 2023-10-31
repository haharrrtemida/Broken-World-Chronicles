using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryInterface : MonoBehaviour
{
    [SerializeField] protected Button _closeInventoryButton;
    [SerializeField] protected Transform _container;
    [SerializeField] protected itemininventory itemPrefab;
    [SerializeField] protected GameObject _infoPanel;

    [Header("Инфопанель")]
    [SerializeField] protected Image _imagePanel;
    [SerializeField] protected TMP_Text _itemNamePanel;
    [SerializeField] protected TMP_Text _itemDescriptionPanel;
    protected InventoryItemSO _activeItem;
    protected List<InventoryItemSO> activeItems;

    protected InventoryMode _mode;

    protected List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        _inInventoryItems = new List<InventoryItemSO>();
        activeItems = new List<InventoryItemSO>();
        _mode = InventoryManager.Instance.GetInventoryMode();
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
        _infoPanel.SetActive(false);
        AddToInventory();
        print(_mode);
    }

    protected void AddToInventory()
    {
        _inInventoryItems = InventoryManager.Instance.GetList();
        for (int i = 0; i < _inInventoryItems.Count; i++)
        {
            var item = _inInventoryItems[i];
            var Item = Instantiate(itemPrefab, _container);
            Item.transform.SetParent(_container);
            Item.transform.localScale = Vector3.one;
            Item.NewItem(item);
            Item.OnItemClicked += OnItemClicked;

            TMP_Text itemText = Item.transform.Find("itemName").GetComponent<TMP_Text>();
            Image itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            itemImage.sprite = item.GetSprite();
            itemText.text = item.Name();
        }
    }

    protected void OnItemClicked(InventoryItemSO item)
    {
        if (_activeItem == item) CloseInfoPanel();
        else ShowInfoPanel(item);
    }

    protected abstract void ShowInfoPanel(InventoryItemSO item);
    protected abstract void CloseInfoPanel();

    public void UseItem()
    {
        InventoryManager.Instance.RemoveItem(_activeItem);
        ScenesManager.Instance.ReloadInventory(_mode);
    }
}
