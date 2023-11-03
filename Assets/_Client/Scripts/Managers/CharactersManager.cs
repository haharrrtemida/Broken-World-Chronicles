using Artemida.Tools;
using UnityEngine;
using UnityEngine.UI;


public class CharactersManager : PersistentSingleton<CharactersManager>
{
    [SerializeField] private WalSO _wal;
    [SerializeField] private TumSO _tum;

    public bool IsCanSwitchLight => _wal.isSwitch;

    private Characters _currentCharacter;

    public void Initialize()
    {
        _wal.SetActive(true);
        _tum.SetActive(true);   
    }

    public void UpdateCharacter(CharacterSO character, bool stateCharacter)
    {
        if (character is WalSO)
        {
            _wal.SetActive(stateCharacter);
        }
        else if (character is TumSO)
        {
            _tum.SetActive(stateCharacter);
        }
    }

    public void SelectWal()
    {
        UpdateStateCharacters(Characters.Wal);
        _wal.Activate();
    }

    public void SelectTum()
    {
        UpdateStateCharacters(Characters.Tum);
        _tum.Activate();
    }

    private void UpdateStateCharacters(Characters character)
    {
        print("Current character is :" + character);    
        if(_currentCharacter == character) return;
        _currentCharacter = character;
    }

    public Characters GetStateCharacter()
    {
        return _currentCharacter;
    }

    public void OpenUIElement(Button ollButton, Button tunButton)
    {
        _wal?.OpenUIElement(ollButton);
        _tum?.OpenUIElement(tunButton);
    }
}