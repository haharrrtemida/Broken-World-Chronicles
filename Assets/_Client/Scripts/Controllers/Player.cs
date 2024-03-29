using Artemida.Tools;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private Transform _pointForItems;
    [SerializeField] private PlayerState _currentState;
    [SerializeField] private CharacterTextBox _characterTextBox;

    public Interectable CurrentInteractable { get; set; }
    public PlayerMotor Movement => _movement;
    public PlayerState CurrentState => _currentState;   
    public CharacterTextBox CharacterTextBox => _characterTextBox;  

    public Vector2 spawnPosition;

    public void Initialize()
    {
        _movement.Initialize();
        SetPlayerState(PlayerState.Idle);
        _movement.OnReachDestination += OnReachDestination;
    }

    private void OnReachDestination()
    {
        print("Player: Target achieved");
        if (CurrentInteractable)
        {
            CurrentInteractable.Interact();
            print("Player: interaction with" + CurrentInteractable.gameObject.name);
        }

        CurrentInteractable = null;
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