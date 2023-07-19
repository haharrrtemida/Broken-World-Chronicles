using Artemida.Tools;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private Transform _pointForItems;

    public void Initialize()
    {
        _movement = GetComponent<PlayerMotor>();
        _movement.Initialize();
    }


    public void Move(Vector2 position)
    {
        _movement.Move(position);
    }

    public void AddRemoveItem()
    {
        var removeList = InventoryManager.Instance.GetRemoveList();
        for (int i = 0; i < removeList.Count; i++)
        {
            var item = removeList[i];
            Instantiate(item.GetMotherPrefab(), _pointForItems.transform);
            print(removeList[i].ToString());
        }
        InventoryManager.Instance.ResetRemoveList();
    }
}