using Artemida.Tools;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : PersistentSingleton<InputManager>
{
    public Vector2 Target { get; private set; }
    private PlayerInput _playerInput;


    public void Initialize()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += context => SetTarget();
        _playerInput.Enable();
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
}
