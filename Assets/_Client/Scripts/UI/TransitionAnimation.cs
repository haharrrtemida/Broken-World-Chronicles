using UnityEngine;

public class TransitionAnimation : MonoBehaviour
{
    private Transition _currentTransition;

    public Transition CurrentTransition
    {
        get
        {
            return _currentTransition;
        }
        set
        {
            _currentTransition = value;
        }
    }

    public void ResetCurrentTransition()
    {
        _currentTransition = null;
    }


    public void ChangeLocation()
    {
        _currentTransition.DoTransition();
    }

    public void EndAnimationTransition()
    {
        gameObject.SetActive(false);
    }
}
