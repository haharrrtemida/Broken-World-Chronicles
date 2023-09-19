using Artemida.Tools;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.AI;

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

        _playerInput.Player.Move.performed += context => OnMouseClick();
        _playerInput.Player.OpenInventory.performed += context => OpenInventory();
        _playerInput.Player.Pause.performed += context => OpenPause();
        _UIActions.Enable();
    }

    private void OnMouseClick()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Player.Instance.CurrentInteractable = SetTarget(mouseWorldPosition);
        Debug.Log("Change Target to: " + Target);

        Player.Instance.Move(Target);
    }

    private Interectable SetTarget(Vector3 position)
    {
        Interectable selectedInteractable = null;
        RaycastHit2D hit = Physics2D.Raycast(position, Camera.main.transform.forward, 20);
        if (hit && hit.transform.TryGetComponent(out selectedInteractable))
        {
            if (selectedInteractable is Zone) selectedInteractable.Interact();
            else Target = selectedInteractable.InteractionPoint.position;
        }
        else
        {
            Target = position;
        }
        return selectedInteractable;
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

    private void OpenInventory()
    {
        ScenesManager.Instance.OpenInventory();
    }

    private void OpenPause()
    {
        UIManager.Instance.OpenPause();
    }
}