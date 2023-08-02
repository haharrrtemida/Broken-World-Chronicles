using Artemida.Tools;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private Transform _pointForItems;
    [SerializeField] private PlayerState _currentState;

    public PlayerMotor Movement => _movement;
    public PlayerState CurrentState => _currentState;   

    public Vector2 spawnPosition;


    public void Initialize()
    {
        _movement.Initialize();
        SetPlayerState(PlayerState.Idle);
        _movement.OnReachDestination += OnReachDestination;
    }

    private void OnReachDestination()
    {
        SetPlayerState(PlayerState.Idle);
    }

    public void MoveToSpawnPoint(Vector3 point)
    {
        transform.position = point;
    }

    public void Move(Vector2 position)
    {
        if (GameManager.Instance.GetGameState() == GameState.Game && _currentState != PlayerState.Acting && _currentState != PlayerState.Speaking)
        {
            _movement.Move(position);
            SetPlayerState(PlayerState.Moving);
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        _currentState = state;
    }
}