using UnityEngine;
using UnityEngine.UI;

public class Oncraft : MonoBehaviour
{
    [SerializeField] private Button _showCraft;
    private CraftItem _item;

    public delegate void OnCraftClickedDelegate(CraftItem item);
    public event OnCraftClickedDelegate OnCraftClicked;

    private void Start()
    {
        _showCraft.onClick.AddListener(ActiveItem);
    }
    public void NewItem(CraftItem item)
    {
        _item = item;
    }

    private void ActiveItem()
    {
        OnCraftClicked?.Invoke(_item);
    }
}
