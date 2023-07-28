using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemininventory : MonoBehaviour
{
    [SerializeField] private GameObject _itemPanel;
    private InventoryItemSO _item;
    private bool _isPanel = true;

    private void OnEnable()
    {
        Button About = gameObject.transform.Find("AboutButton").GetComponent<Button>();
        About.onClick.AddListener(ShowPanelAbout);
    }

    public void NewItem(InventoryItemSO item)
    {
        _item = item;
    }

    private void ShowPanelAbout()
    {
        if (_isPanel)
        {
            FindObjectOfType<InventoryInterface>().InfoPanel(_item);
            _isPanel = false;
        }
        else if (!_isPanel)
        {
            FindObjectOfType<InventoryInterface>().CloseInfoPanel();
            _isPanel = true;
        }
    }
}
