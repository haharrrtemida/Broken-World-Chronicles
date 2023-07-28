using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemininventory : MonoBehaviour
{
    [SerializeField] private GameObject _itemPanel;
    private InventoryItemSO _item;
    private bool _isPanel = false;
    private GameObject _newPanel;

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
        if (!_isPanel)
        {
            _newPanel = Instantiate(_itemPanel, gameObject.transform);
            var Stats = _newPanel.transform.Find("Stats").GetComponent<Transform>();
            TMP_Text name = Stats.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text about = Stats.transform.Find("About").GetComponent<TMP_Text>();
            TMP_Text comment = Stats.transform.Find("Comment").GetComponent<TMP_Text>();

            name.text = _item.Name();
            about.text = _item.About();
            comment.text = _item.Comment();
            _isPanel = true;
        }
        else if (_isPanel)
        {
            Destroy(_newPanel);
            _isPanel = false;
        }
    }
}
