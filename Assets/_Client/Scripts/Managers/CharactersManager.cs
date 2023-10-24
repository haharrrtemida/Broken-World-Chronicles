using Artemida.Tools;
using UnityEngine;
using UnityEngine.UI;


public class CharactersManager : PersistentSingleton<CharactersManager>
{
    [SerializeField] private Oll _oll;
    [SerializeField] private Tun _tun;

    [SerializeField] private Character _activeCharacter;

    private Characters _currentCharacter;

    public void Initialize()
    {
        _oll.SetActive(true);
    }

    public void SelectOll()
    {
        Select(_oll);
    }

    public void SelectTun()
    {
        Select(_tun);
    }

    private void Select(Character character)
    {
        _activeCharacter = character;
        _activeCharacter?.Activate();
        
        if (_activeCharacter is Tun)
        {
            UpdateStateCharacters(Characters.Tun);
        }
        else if (_activeCharacter is Oll)
        {
            UpdateStateCharacters(Characters.Oll);
        }

    }

    private void UpdateStateCharacters(Characters character)
    {
        if(_currentCharacter == character) return;
        _currentCharacter = character;
    }

    public void OpenUIElement(Button ollButton, Button tunButton)
    {
        _oll.OpenUIElement(ollButton);
        _tun.OpenUIElement(tunButton);
    }
}