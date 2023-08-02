using UnityEngine;
using Artemida.Tools;

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private GameObject AnimationTransition;
    [SerializeField] private TransitionAnimation _transitionAnimation;
    [SerializeField] private Animator _animator;

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
}
