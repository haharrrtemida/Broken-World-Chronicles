using UnityEngine;

public class Pause : MonoBehaviour
{
    public void ClosePause()
    {
        if (GameManager.Instance.GetGameState() == GameState.Pause)
        {
            GameManager.Instance.UpdateGameState(GameState.Game);
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }

    public void Save()
    {

    }

    public void ExitInMainMenu()
    {
        ClosePause();
        Destroy(Player.Instance.gameObject);
        ScenesManager.Instance.LoadMainMenu();
    }
}
