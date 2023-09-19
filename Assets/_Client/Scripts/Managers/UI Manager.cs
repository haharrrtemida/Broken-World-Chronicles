using UnityEngine;
using Artemida.Tools;

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private GameObject AnimationTransition;
    [SerializeField] private TransitionAnimation _transitionAnimation;
    [SerializeField] private Animator _animator;
    [SerializeField] private Pause _pause;

    const string TRANSITION_TRIGGER_PARAM = "TransitionComplete";
    public TransitionAnimation TransitionAnimation => _transitionAnimation;
    public void SetTransitionTrigger()
    {
        _animator.SetTrigger(TRANSITION_TRIGGER_PARAM);
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
            _pause.ClosePause();
        }
    }
}
