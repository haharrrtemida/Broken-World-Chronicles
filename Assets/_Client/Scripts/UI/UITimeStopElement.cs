using UnityEngine;

public abstract class UITimeStopElement : MonoBehaviour 
{
    public virtual void Close()
    {
       if (GameManager.Instance.GetGameState() == GameState.Pause || GameManager.Instance.GetGameState() == GameState.ChoiceCharacter)
       {
            GameManager.Instance.UpdateGameState(GameState.Game);
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }    
}