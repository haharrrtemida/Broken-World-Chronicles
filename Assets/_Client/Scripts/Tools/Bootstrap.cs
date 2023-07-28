 using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private void Start()
    {
        GameManager.Instance.Initialize();
        InputManager.Instance.Initialize();
        ScenesManager.Instance.Initialize();
        ScenesManager.Instance.LoadMainMenu();
    }
}