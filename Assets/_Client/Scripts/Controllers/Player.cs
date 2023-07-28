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
        if (GameManager.Instance.GetGameState() == GameState.Game)
        {
            _movement.Move(position);
        }
    }
}