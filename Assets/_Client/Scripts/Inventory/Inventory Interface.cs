using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _inventory;
    [SerializeField] private itemininventory itemPrefab;
    private List<InventoryItemSO> _inInventoryItems;

    private void Start()
    {
        GameManager.Instance.UpdateGameState(GameState.Inventory);
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
            Item.NewItem(item);

            TMP_Text itemText = Item.transform.Find("itemName").GetComponent<TMP_Text>();
            var itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            itemImage.sprite = item.GetSprite();
            itemText.text = item.Name();
        }
    }
}
