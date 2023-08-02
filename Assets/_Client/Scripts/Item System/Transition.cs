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
        StartCoroutine(StartTransition());
    }

    public bool DistanceToPlayer => Vector2.Distance(transform.position, Player.Instance.transform.position) <= _activateDistances;

    private IEnumerator StartTransition()
    {
        yield return new WaitWhile(Player.Instance.Movement.IsMoving);
        UIManager.Instance.StartAnimationTransition();
        GameManager.Instance.UpdateGameState(GameState.Transition);
        Player.Instance.Movement.TeleportToPoint(_exitPosition.position);
        Camera.main.transform.position = _cameraExitPosition.position;
        UIManager.Instance.ûûû();
        GameManager.Instance.UpdateGameState(GameState.Game);
    }
}   