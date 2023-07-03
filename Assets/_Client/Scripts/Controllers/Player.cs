using Artemida.Tools;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private PlayerMotor _movement;

    public void Initialize()
    {
        _movement = GetComponent<PlayerMotor>();
        _movement.Initialize();
        InventoryManager.Instance.Initialize();
    }


    public void Move(Vector2 position)
    {
        _movement.Move(position);
    }
}