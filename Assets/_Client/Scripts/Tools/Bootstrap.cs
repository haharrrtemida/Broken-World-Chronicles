 using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Initialize();
        InputManager.Instance.Initialize();
        ScenesManager.Instance.Initialize();
        InventoryManager.Instance.Initialize();
        ScenesManager.Instance.LoadMainMenu();
    }
}