using Artemida.Tools;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private Transform _pointForItems;
    [SerializeField] private GameObject _player;

    public PlayerMotor Movement => _movement;

    public Vector2 spawnPosition;
    public void Initialize()
    {
        _movement.Initialize();
    }

    public void MoveToSpawnPoint(Vector3 point)
    {
        transform.position = point;
    }

    public void Move(Vector2 position)
    {
        if (GameManager.Instance.GetGameState() == GameState.Game)
        {
            _movement.Move(position);
        }
    }
}