using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _container;
    [SerializeField] private itemininventory itemPrefab;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private CraftItem[] craftItems;

    [Header("Инфопанель")]
    [SerializeField] private Image _imagePanel;
    [SerializeField] private TMP_Text _itemNamePanel;
    [SerializeField] private TMP_Text _itemDescriptionPanel;
    private InventoryItemSO _activeItem;
    private List<InventoryItemSO> activeItems;

    private string craftItemsNames;

    private InventoryMode _mode;

    private List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        _inInventoryItems = new List<InventoryItemSO>();
        activeItems = new List<InventoryItemSO>();
        _mode = InventoryManager.Instance.GetInventoryMode();
        _closeInventoryButton.onClick.AddListener(ScenesManager.Instance.CloseInventory);
        _infoPanel.SetActive(false);
        AddToInventory();
        print(_mode);
    }

    private void AddToInventory()
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

    private void OnItemClicked(InventoryItemSO item)
    {
        if (_activeItem == item) CloseInfoPanel();
        else ShowInfoPanel(item);
    }

    private void ShowInfoPanel(InventoryItemSO item)
    {
        _activeItem = item;
        if (_mode == InventoryMode.Inventory)
        {
            _imagePanel.sprite = item.GetSprite();
            _itemNamePanel.text = item.Name();
            _itemDescriptionPanel.text = item.About();
            _infoPanel.SetActive(true);
        }
        else if (_mode == InventoryMode.Craft)
        {
            activeItems.Add(item);
            print(item.Name());
            CraftLogik();
        }
    }
    private void CloseInfoPanel()
    {
        _activeItem = null;
        activeItems = null;
        _infoPanel.SetActive(false);
    }

    public void UseItem()
    {
        InventoryManager.Instance.RemoveItem(_activeItem);
        ScenesManager.Instance.ReloadInventory(_mode);
    }
    private void CraftLogik()
    {
        for (int i = 0; i < activeItems.Count; i++)
        {
            craftItemsNames = activeItems[i].Name();
            print(activeItems[i].Name());
        }
        _itemNamePanel.text = craftItemsNames;
        _infoPanel.SetActive(true);

        for (int i = 1; i < craftItems.Length; i++)
        {
            CraftItem itemCraft = craftItems[i];
            if (Enumerable.SequenceEqual(activeItems, itemCraft.GetComponents()))
            {
                InventoryManager.Instance.AddItem(itemCraft.GetItemSOAustCraftItem());
                for (int a = 0; a < activeItems.Count; a++)
                {
                    InventoryManager.Instance.RemoveItem(activeItems[a]);
                    print("CRAFTING.....");
                }
                ScenesManager.Instance.ReloadInventory(_mode);
            }
            else
            {
                _itemDescriptionPanel.text = "none";
            }
        }
    }
}
