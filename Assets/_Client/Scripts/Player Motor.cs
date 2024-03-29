using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private AnimationPlayer _animationPlayer;

    public event Action OnReachDestination;

    private Vector2 _targetPosition;
    public Vector2 TargetPosition => _targetPosition; 

    public void Initialize()
    {
        OnReachDestination += StopOnReachDestination;
    }

    private void StopOnReachDestination()
    {
        _agent.isStopped = true;
        _animationPlayer.ResetParam();
    }

    public void Move(Vector2 position)
    {
        _targetPosition = position;
        _agent.isStopped = false;
        _agent.SetDestination(_targetPosition);
        _animationPlayer.AnimationMove();
    }

    public void TeleportToPoint(Vector2 position)
    {
        _agent.enabled = false;
        transform.position = position;
        _agent.enabled = true;
    }

    private void Update()
    {
        if (IsReachDestination && Player.Instance.CurrentState == PlayerState.Moving)
        {
            OnReachDestination?.Invoke();
        }
    }

    private bool IsReachDestination => Vector2.Distance(transform.position, _targetPosition) <= _agent.stoppingDistance;
}