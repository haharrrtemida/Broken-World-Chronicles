using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void Play()
    {
        ScenesManager.Instance.LoadNewGame();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
