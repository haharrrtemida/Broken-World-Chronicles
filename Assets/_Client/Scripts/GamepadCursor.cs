using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem;
using UnityEngine;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private RectTransform _cursorRectTransform;
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _cursorSpeed;

    private bool previousMouseState;
    private Mouse _virtualMouse;

    private void OnEnable()
    {
        if (_virtualMouse == null)
        {
            _virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if (!_virtualMouse.added)
        {
            InputSystem.AddDevice(_virtualMouse);
        }

        InputUser.PerformPairingWithDevice(_virtualMouse);

        if (_cursorRectTransform != null)
        {
            Vector2 position = _cursorRectTransform.anchoredPosition;
            InputState.Change(_virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
    }

    private void OnDisable()
    {
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    private void UpdateMotion()
    {
        if (_virtualMouse != null || Gamepad.current == null)
        {
            return;
        }

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        deltaValue *= _cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = _virtualMouse.position.ReadValue();
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);
        newPosition.y = Mathf.Clamp(newPosition.y, 0, Screen.height);

        InputState.Change(_virtualMouse.position, newPosition);
        InputState.Change(_virtualMouse.delta, deltaValue);

        bool aButtonIsPressed = Gamepad.current.aButton.isPressed;

        if (previousMouseState != aButtonIsPressed)
        {
            _virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(_virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, position, _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main, out anchoredPosition);
        _cursorRectTransform.anchoredPosition = anchoredPosition;
    }
}
