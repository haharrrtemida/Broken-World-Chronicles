using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : Zone
{   
    [SerializeField] private SceneName _nextScene;
    [SerializeField] private Vector2 _exitPosition;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(TransitionToScene());
    }
    private IEnumerator TransitionToScene()
    {
        yield return new WaitForSeconds(5);
        ScenesManager.Instance.LoadScene(_nextScene);
        Player.Instance.gameObject.transform.position = _exitPosition;
        Player.Instance.Move(_exitPosition);
    }
}