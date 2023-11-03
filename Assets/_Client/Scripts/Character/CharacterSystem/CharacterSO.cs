using UnityEngine.UI;
using UnityEngine;

public abstract class CharacterSO : ScriptableObject
{

    private bool isCharacterOpen = false;

    public abstract void Activate();

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
}