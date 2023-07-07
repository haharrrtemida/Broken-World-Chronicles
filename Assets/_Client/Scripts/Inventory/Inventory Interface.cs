using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private Transform _inventory;
    [SerializeField] private GameObject itemPrefab;
    private List<InventoryItemSO> _inInventoryItems;
    public List<InventoryItemSO> _startItems;

    private void Start()
    {
        _inInventoryItems.Clear();
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
        AddToInventory();
    }

    private void AddToInventory()
    {
        _inInventoryItems = InventoryManager.Instance.GetList();
        for (int i = 0; i < _inInventoryItems.Count; i++)
        {
            var item = _inInventoryItems[i];
            GameObject Item = Instantiate(itemPrefab, _inventory);
            Item.transform.SetParent(_inventory);
            Item.transform.localScale = new Vector3(1, 1, 1);

            var itemText = Item.transform.Find("itemText").GetComponent<Text>();
            var itemImage = Item.transform.Find("itemImage").GetComponent<Image>();

            itemText.text = item.name;
            itemImage.sprite = item.GetSprite();
        }
    }
}
