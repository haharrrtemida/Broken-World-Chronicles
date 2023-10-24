using System.Collections;
using UnityEngine;

public class Transition : Interectable
{
    [SerializeField] private Transform _exitPosition;
    [SerializeField] private Transform _cameraExitPosition;

    private string[] _NoEntyString = {"�����", "�������"};

    public override void Interact()
    {
        if (_exitPosition == null)
        {
            Player.Instance.CharacterTextBox.SetText(_NoEntyString);
            print("No entry");
            return;
        }
        base.Interact();
        UIManager.Instance.TransitionAnimation.CurrentTransition = this;
        StartTransition();
    }   

    public void DoTransition()
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