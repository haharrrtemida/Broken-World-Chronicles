using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour
{
    [SerializeField] private Oncraft _craftItemPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private List<CraftItem> _allCraftItems;

    [Header("Ингридиенты")]
    [SerializeField] private Transform _ingridientContainer;
    [SerializeField] private GameObject _ingridientPrefab;
    [SerializeField] private GameObject _ingridientsInterfase;
    private CraftItem _activeItem;

    private void Start()
    {
        _ingridientsInterfase.SetActive(false);
        AddAllItemsToCraft();
    }

    private void AddAllItemsToCraft()
    {
        for(int i = 0; i < _allCraftItems.Count; i++)
        {
            CraftItem item = _allCraftItems[i];
            var Item = Instantiate(_craftItemPrefab, _container);
            Item.transform.SetParent(_container);
            Item.transform.localScale = new Vector3(1, 1, 1);
            Item.NewItem(item);
            Item.OnCraftClicked += OnCraftClicked;

            TMP_Text itemText = Item.transform.Find("itemName").GetComponent<TMP_Text>();
            Image itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            InventoryItemSO itemSO = item.GetItemSO();
            itemImage.sprite = itemSO.GetSprite();
            itemText.text = itemSO.Name();
        }
    }

    public void ShowIngridient(CraftItem item)
    {
        _activeItem = item;
        for (int i = 0; i < item.GetResourses().Count; i++)
        {
            InventoryItemSO itemSO = item.GetResourses()[i];
            GameObject ingridient = Instantiate(_ingridientPrefab, _container);
            ingridient.transform.SetParent(_ingridientContainer);
            ingridient.transform.localScale = new Vector3(1, 1, 1);

            TMP_Text ingridientText = ingridient.transform.Find("ingridientName").GetComponent<TMP_Text>();
            Image ingridientImage = ingridient.transform.Find("ingridientImage").GetComponent<Image>();

            ingridientImage.sprite = itemSO.GetSprite();
            ingridientText.text = itemSO.Name();
            _ingridientsInterfase.SetActive(true);
        }
    }

    public void CloseInridient()
    {
        _activeItem = null;
        _ingridientsInterfase.SetActive(false);
    }

    private void OnCraftClicked(CraftItem item)
    {
        if (_activeItem == item) CloseInridient();
        else ShowIngridient(item);
    }

    public void Craft()
    {
        InventoryItemSO AddItem = _activeItem.GetItemSO();
        InventoryManager.Instance.AddItem(AddItem);
        List<InventoryItemSO> removeItem = _activeItem.GetResourses();
        for (int i = 0; i < removeItem.Count; i++)
        {
            InventoryManager.Instance.RemoveItem(removeItem[i]);
        }
        ScenesManager.Instance.ReloadInventory();
    }
}
