using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : Zone
{   
    [SerializeField] private SceneName _nextScene;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(TransitionToScene());
    }

    private IEnumerator TransitionToScene()
    {
        yield return new WaitForSeconds(5);
        ScenesManager.Instance.LoadScene(_nextScene);
    }
}