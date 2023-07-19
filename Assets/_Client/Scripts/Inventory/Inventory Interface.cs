using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _inventory;
    [SerializeField] private GameObject itemPrefab;
    private List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        _inInventoryItems = new List<InventoryItemSO>();
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
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
            Item.GetComponent<itemininventory>().NewItem(item);

            var itemText = Item.transform.Find("itemName").GetComponent<Text>();
            var itemImage = Item.transform.Find("itemImage").GetComponent<Image>();
            var removeButton = Item.transform.Find("RemoveButton").GetComponent<Button>();

            removeButton.onClick.AddListener(Item.GetComponent<itemininventory>().Delete);
            itemImage.sprite = item.GetSprite();
            //itemText.text = item.Name();            
        }
    }
}
