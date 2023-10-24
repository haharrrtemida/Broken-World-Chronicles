using UnityEngine.UI;

public abstract class Character
{
    public CapabilitiesSO[] _capabilities;
    private bool isCharacterOpen = false;

    public abstract void Activate();

    public void SetActive(bool state)
    {
        isCharacterOpen = state;
    }

    public void OpenUIElement(Button CharacterButton)
    {
        if(isCharacterOpen)
        {
            CharacterButton.gameObject.SetActive(true);
        }
    }
}