using Artemida.Tools;
using UnityEngine;
using UnityEngine.UI;


public class CharactersManager : PersistentSingleton<CharactersManager>
{
    [SerializeField] private WalSO _wal;
    [SerializeField] private TumSO _tum;            

    private Characters _currentCharacter;

    public void Initialize()
    {
        _wal.SetActive(true);
        _tum.SetActive(true);   
    }

    public void UpdateStateCharacter(CharacterSO character, bool stateCharacter)
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
        _tum.Deactivate();
        _wal.Activate();
        UIManager.Instance.ChangeCurrentCharacterText(_wal.GetName());
    }

    public void SelectTum()
    {
        UpdateStateCharacters(Characters.Tum);
        _wal.Deactivate();
        _tum.Activate();
        UIManager.Instance.ChangeCurrentCharacterText(_tum.GetName());
    }

    private void UpdateStateCharacters(Characters character)
    {
        print("Current character is :" + character);    
        if(_currentCharacter == character) return;
        _currentCharacter = character;
    }

    public Characters GetStateCharacter() => _currentCharacter;

    public void OpenUIElement(Button ollButton, Button tunButton)
    {
        _wal?.OpenUIElement(ollButton);
        _tum?.OpenUIElement(tunButton);
    }
}