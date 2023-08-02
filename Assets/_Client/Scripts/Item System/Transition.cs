using System.Collections;
using UnityEngine;

public class Transition : Zone
{
    [SerializeField] private Transform _exitPosition;
    [SerializeField] private Transform _cameraExitPosition;
    [SerializeField] private float _activateDistances;


    protected override void Interact()
    {
        base.Interact();
        UIManager.Instance.TransitionAnimation.CurrentTransition = this;
        StartTransition();
    }   
    public bool DistanceToPlayer => Vector2.Distance(transform.position, Player.Instance.transform.position) <= _activateDistances;

    public void ff()
    {
        GameManager.Instance.UpdateGameState(GameState.Transition);
        Player.Instance.Movement.TeleportToPoint(_exitPosition.position);
        Camera.main.transform.position = _cameraExitPosition.position;
        UIManager.Instance.SetTransitionTrigger();
        GameManager.Instance.UpdateGameState(GameState.Game);
    }

    private void StartTransition()
    {
        UIManager.Instance.StartAnimationTransition();
    }
}   