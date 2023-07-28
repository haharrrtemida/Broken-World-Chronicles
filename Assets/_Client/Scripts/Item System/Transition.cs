using System.Collections;
using UnityEngine;

public class Transition : Zone
{
    [SerializeField] private Transform _exitPosition;
    [SerializeField] private Transform _cameraExitPosition;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(TransitionToScene());
    }
    private IEnumerator TransitionToScene()
    {
        yield return new WaitForSeconds(1);

        while (Player.Instance.Movement.Agent.isStopped)
        {
            yield return new WaitForSeconds(1);
        }

        Player.Instance.Movement.Agent.enabled = false;
        Player.Instance.gameObject.transform.position = _exitPosition.position;
        Player.Instance.Movement.Agent.enabled = true;
        Camera.main.transform.position = _cameraExitPosition.position;
    }
}