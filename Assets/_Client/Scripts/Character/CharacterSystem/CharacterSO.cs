using UnityEngine.UI;
using UnityEngine;

public abstract class CharacterSO : ScriptableObject
{
    [SerializeField] private string _name;

    private bool isCharacterOpen = false;

    public abstract void Activate();
    public abstract void Deactivate();

    public void SetActive(bool stateCharcter)
    {
        isCharacterOpen = stateCharcter;
    }

    public void OpenUIElement(Button CharacterButton)
    {
        if(isCharacterOpen)
        {
            CharacterButton.gameObject.SetActive(true);
        }
    }

    public string GetName() => _name;
}