using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Button _closeInventoryButton;
    [SerializeField] private RectTransform _inventory;

    private void Start()
    {
        _closeInventoryButton.onClick.AddListener(InventoryManager.Instance.CloseInventory);
    }

    private void AddToInventory()
    {
        //for (int i = 0; i < _inventoryManager._inventoryItems.Count; i++)
        //{
        //    var item = _inventoryManager._inventoryItems[i];
        //    var icon = new GameObject(item.name);
        //    icon.transform.SetParent(_inventory);
        //    icon.AddComponent<Image>().sprite = item.GetSprite();
        //}
    }
}
