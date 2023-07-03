using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.Initialize();
        GameManager.Instance.Initialize();
        ScenesManager.Instance.Initialize();
        ScenesManager.Instance.LoadMainMenu();
    }
}