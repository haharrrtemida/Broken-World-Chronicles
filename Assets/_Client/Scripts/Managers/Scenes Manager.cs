using Artemida.Tools;
using UnityEngine.SceneManagement;

public class ScenesManager : PersistentSingleton<ScenesManager>
{
    public void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case ((int)SceneName.Level01):
                GameManager.Instance.UpdateGameState(GameState.Game);
                break;
        }

    }

    public void LoadScene(SceneName scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(scene.ToString(), mode);
    }

    public void LoadMainMenu()
    {
        LoadScene(SceneName.MainMenu);
        InputManager.Instance.ActivateUIMap();
    }

    public void LoadNewGame()
    {
        LoadScene(SceneName.Level01);
        InputManager.Instance.ActivatePlayerMap();
        GameManager.Instance.UpdateGameState(GameState.OpenLevel);
    }

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene((SceneName)index);
    }

    public void OpenInventory()
    {
        LoadScene(SceneName.Inventory, LoadSceneMode.Additive);
    }

    public void CloseInventory()
    {
        SceneManager.UnloadSceneAsync(SceneName.Inventory.ToString());
    }
}