using Artemida.Tools;
using UnityEngine.SceneManagement;

public class ScenesManager : PersistentSingleton<ScenesManager>
{
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadMainMenu()
    {
        LoadScene(Scene.MainMenu);
    }

    public void LoadNewGame()
    {
        LoadScene(Scene.Level01);
    }

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene((Scene)index);
    }
}