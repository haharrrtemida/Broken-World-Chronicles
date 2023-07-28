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
        StartCoroutine(TransitionToScene());
    }

    public bool DistanceToPlayer => Vector2.Distance(transform.position, Player.Instance.transform.position) <= _activateDistances;

    private IEnumerator TransitionToScene()
    {
        yield return new WaitUntil(Player.Instance.Movement.IsMoving);

        Player.Instance.Movement.TeleportToPoint(_exitPosition.position);
        Camera.main.transform.position = _cameraExitPosition.position;
    }
}