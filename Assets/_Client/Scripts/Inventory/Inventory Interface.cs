using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _inventory;
    [SerializeField] private itemininventory itemPrefab;
    [SerializeField] private GameObject _infoPanel;
    private List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        _inInventoryItems = new List<InventoryItemSO>();
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
        _infoPanel.SetActive(false);
        AddToInventory();
    }

    private void AddToInventory()
    {
        _inInventoryItems = InventoryManager.Instance.GetList();
        for (int i = 0; i < _inInventoryItems.Count; i++)
        {
            var item = _inInventoryItems[i];
            var Item = Instantiate(itemPrefab, _inventory);
            Item.transform.SetParent(_inventory);
            Item.transform.localScale = new Vector3(1, 1, 1);
            Item.NewItem(item);

            TMP_Text itemText = Item.transform.Find("itemName").GetComponent<TMP_Text>();
            var itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            itemImage.sprite = item.GetSprite();
            itemText.text = item.Name();
        }
    }

    public void InfoPanel(InventoryItemSO _item)
    {
        var image = _infoPanel.transform.Find("Image").GetComponent<Image>();
        TMP_Text name = _infoPanel.transform.Find("Name").GetComponent<TMP_Text>();
        TMP_Text about = _infoPanel.transform.Find("About").GetComponent<TMP_Text>();

        image.sprite = _item.GetSprite();
        name.text = _item.Name();
        about.text = _item.About();
        _infoPanel.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        _infoPanel.SetActive(false);
    }
}
