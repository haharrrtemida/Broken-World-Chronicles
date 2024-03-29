using UnityEngine;
public class Item : Interectable
{
    [SerializeField] private InventoryItemSO _item;
    public override void Interact()
    {
        base.Interact();
        InventoryManager.Instance.AddItem(_item);
        Destroy(gameObject);
    }
}