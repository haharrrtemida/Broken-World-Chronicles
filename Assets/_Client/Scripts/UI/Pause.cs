using UnityEngine;

public class Pause : UITimeStopElement
{

    public void Save()
    {

    }

    public void ExitInMainMenu()
    {
        Close();
        Destroy(Player.Instance.gameObject);
        ScenesManager.Instance.LoadMainMenu();
    }
}
