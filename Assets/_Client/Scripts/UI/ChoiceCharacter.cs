using UnityEngine.UI;
using UnityEngine;

public class ChoiceCharacter : UITimeStopElement
{
    [SerializeField] private Button _ollButton;
    [SerializeField] private Button _tunButton;

    public void SelectOll()
    {
        CharactersManager.Instance.SelectOll();
    }

    public void SelectTun()
    {
        CharactersManager.Instance.SelectTun();
    }
    
    public void InitializePanel()
    {
        CharactersManager.Instance.OpenUIElement(_ollButton, _tunButton);
    }

    public override void Close()
    {
        base.Close();
        _ollButton.gameObject.SetActive(false);
        _tunButton.gameObject.SetActive(false);
    }
}