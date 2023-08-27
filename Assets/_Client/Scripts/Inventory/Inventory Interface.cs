using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _container;
    [SerializeField] private itemininventory itemPrefab;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _craftPanel;

    [Header("����������")]
    [SerializeField] private Image _imagePanel;
    [SerializeField] private TMP_Text _itemNamePanel;
    [SerializeField] private TMP_Text _itemDescriptionPanel;
    private InventoryItemSO _activeItem;

    private bool _currentStateCraftPanel = false;

    private List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        _inInventoryItems = new List<InventoryItemSO>();
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
        _infoPanel.SetActive(false);
        _craftPanel.SetActive(false);
        AddToInventory();
    }

    private void AddToInventory()
    {
        _inInventoryItems = InventoryManager.Instance.GetList();
        for (int i = 0; i < _inInventoryItems.Count; i++)
        {
            var item = _inInventoryItems[i];
            var Item = Instantiate(itemPrefab, _container);
            Item.transform.SetParent(_container);
            Item.transform.localScale = new Vector3(1, 1, 1);
            Item.NewItem(item);
            Item.OnItemClicked += OnItemClicked;

            TMP_Text itemText = Item.transform.Find("itemName").GetComponent<TMP_Text>();
            Image itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            itemImage.sprite = item.GetSprite();
            itemText.text = item.Name();
        }
    }

    private void OnItemClicked(InventoryItemSO item)
    {
        if (_activeItem == item) CloseInfoPanel();
        else ShowInfoPanel(item);
    }

    public void ShowInfoPanel(InventoryItemSO item)
    {
        _activeItem = item;
        _imagePanel.sprite = item.GetSprite();
        _itemNamePanel.text = item.Name();
        _itemDescriptionPanel.text = item.About();
        _infoPanel.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        _activeItem = null;
        _infoPanel.SetActive(false);
    }

    public void UseItem()
    {
        if (_activeItem != null && _activeItem.Craftable != true) InventoryManager.Instance.RemoveItem(_activeItem);
        ScenesManager.Instance.ReloadInventory();
    }

    public void ShowOrCloseCraftPanel()
    {
        if (_currentStateCraftPanel == false)
        {
            _craftPanel.SetActive(true);
            _infoPanel.SetActive(false);
        }
        else
        {
            _craftPanel.SetActive(false);
            _infoPanel.SetActive(false);
        }
        _currentStateCraftPanel = !_currentStateCraftPanel;
    }
}
