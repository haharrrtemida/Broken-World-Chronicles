using Artemida.Tools;
using UnityEngine;
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
        GameManager.Instance.UpdateGameState(GameState.MainMenu);
        InputManager.Instance.ActivateUIMap();
    }

    public void LoadNewGame()
    {
        LoadScene(SceneName.Level01);
        InputManager.Instance.ActivatePlayerMap();
        GameManager.Instance.UpdateGameState(GameState.OpenLevel);
        UIManager.Instance.InitializeUI();
    }

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene((SceneName)index);
    }

    public void LoadPreviousScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        LoadScene((SceneName)index);
    }

    public void OpenInventory(InventoryMode mode)
    {
        if (GameManager.Instance.GetGameState() == GameState.Game || GameManager.Instance.GetGameState() == GameState.ChoiceCharacter)
        {
            LoadScene(SceneName.Inventory, LoadSceneMode.Additive);
            InventoryManager.Instance.ChangeModeInventory(mode);
            GameManager.Instance.UpdateGameState(GameState.Inventory);
        }
    }

    public void CloseInventory()
    {
        if (GameManager.Instance.GetGameState() == GameState.Inventory)
        {
            SceneManager.UnloadSceneAsync(SceneName.Inventory.ToString());
            GameManager.Instance.UpdateGameState(GameState.Game);
        }
    }

    public void ReloadInventory(InventoryMode mode)
    {
        CloseInventory();
        OpenInventory(mode);
    }
}