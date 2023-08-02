using UnityEngine;
using Artemida.Tools;

public class UIManager : PersistentSingleton<UIManager>
{
    public GameObject Transition;
    [SerializeField] private Animator _animator;
    const string TRANSITION_TRIGGER_PARAM = "TransitionComplete";

    public void ûûû()
    {
        _animator.SetTrigger(TRANSITION_TRIGGER_PARAM);

    }

    public void StartAnimationTransition()
    {
        Transition.SetActive(true);
    }
}
