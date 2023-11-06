using UnityEngine.UI;
using UnityEngine;

public class ChoiceCharacter : UITimeStopElement
{
    [SerializeField] private Button _walButton;
    [SerializeField] private Button _tumButton;

    public void SelectWal()
    {
        CharactersManager.Instance.SelectWal();
        Close();
    }

    public void SelectTum()
    {
        CharactersManager.Instance.SelectTum();
        Close();
    }
    
    public void InitializePanel()
    {
        CharactersManager.Instance.OpenUIElement(_walButton, _tumButton);
    }

    public override void Close()
    {
        _walButton.gameObject.SetActive(false);
        _tumButton.gameObject.SetActive(false);
        if (GameManager.Instance.GetGameState() != GameState.Inventory)
        {
            GameManager.Instance.UpdateGameState(GameState.Game);
        }
        base.Close();
    }
}