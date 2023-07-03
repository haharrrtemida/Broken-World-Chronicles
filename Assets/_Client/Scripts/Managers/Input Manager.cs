using Artemida.Tools;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : PersistentSingleton<InputManager>
{
    public Vector2 Target { get; private set; }
    
    private PlayerInput _playerInput;
    private PlayerInput.PlayerActions _playerActions;
    private PlayerInput.UIActions _UIActions;


    public void Initialize()
    {
        _playerInput = new PlayerInput();
        _playerActions = _playerInput.Player;
        _UIActions = _playerInput.UI;

        _playerInput.Player.Move.performed += context => SetTarget();
        _playerInput.Player.OpenInventory.performed += context => OpenInventory();
        _UIActions.Enable();
    }

    private void SetTarget()
    {
        Target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log("Change Target to: " + Target);
        Player.Instance.Move(Target);
    }

    private void OnEnable()
    {
        _playerInput?.Enable();
    }

    private void OnDisable()
    {
        _playerInput?.Disable();
    }

    private void ToggleActionMap(InputActionMap map)
    {
        if (map.enabled) return;
        _playerInput.Disable();
        map.Enable();
    }

    public void ActivateUIMap()
    {
        ToggleActionMap(_UIActions);
    }

    public void ActivatePlayerMap()
    {
        ToggleActionMap(_playerActions);
    }

    public void OpenInventory()
    {
        ScenesManager.Instance.OpenInventory();
    }
}