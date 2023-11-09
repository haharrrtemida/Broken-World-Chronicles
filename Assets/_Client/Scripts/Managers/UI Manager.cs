using UnityEngine;
using TMPro;
using Artemida.Tools;
using System;

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private GameObject AnimationTransition;
    [SerializeField] private TransitionAnimation _transitionAnimation;
    [SerializeField] private Animator _animator;
    [SerializeField] private ChoiceCharacter _choiceCharacter;
    [SerializeField] private Pause _pause;
    [SerializeField] private TextMeshProUGUI _currentCharacterText;

    const string TRANSITION_TRIGGER_PARAM = "TransitionComplete";
    public TransitionAnimation TransitionAnimation => _transitionAnimation;


    public void InitializeUI()
    {
        _currentCharacterText.gameObject.SetActive(true);
        ChangeCurrentCharacterText("None");
    }

    public void CloseUI()
    {
        _currentCharacterText.gameObject.SetActive(false);
    }

    public void SetTransitionTrigger()
    {
        _animator.SetTrigger(TRANSITION_TRIGGER_PARAM);
    }

    public void ChangeCurrentCharacterText(string currentCharacterName)
    {
        _currentCharacterText.text = "Current character : " + currentCharacterName;
    }

    public void StartAnimationTransition()
    {
        AnimationTransition.SetActive(true);
    }

    public void OpenPause()
    {
        if (GameManager.Instance.GetGameState() == GameState.Game)
        {
            GameManager.Instance.UpdateGameState(GameState.Pause);
            Time.timeScale = 0;
            _pause.gameObject.SetActive(true);
        }
        else
        {
            _pause.Close();
        }
    }

    public void OpenChoiceCharacter()
    {
        if (GameManager.Instance.GetGameState() == GameState.Game)
        {
            GameManager.Instance.UpdateGameState(GameState.ChoiceCharacter);
            Time.timeScale = 0.0f;
            _choiceCharacter.gameObject.SetActive(true);
            _choiceCharacter.InitializePanel();
        }
        else 
        {
            _choiceCharacter.Close();
        }
    }
}
