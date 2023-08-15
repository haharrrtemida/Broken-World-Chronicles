using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _playerAnimator;

    public event Action OnReachDestination;

    private Vector2 _targetPosition;

    public void Initialize()
    {
        OnReachDestination += StopOnReachDestination;
    }

    private void StopOnReachDestination()
    {
        _agent.isStopped = true;
        _playerAnimator.SetFloat("AnimMoveX", 0);
        _playerAnimator.SetFloat("AnimMoveY", 0);
    }

    public void Move(Vector2 position)
    {
        _targetPosition = position;
        _agent.isStopped = false;
        _agent.SetDestination(_targetPosition);
        //position = new Vector2(position.x, position.y).normalized;

        Vector2 direction = _targetPosition - (Vector2)transform.position;
        direction.Normalize();
        direction.x = Mathf.RoundToInt(direction.x);
        direction.y = Mathf.RoundToInt(direction.y);

        _playerAnimator.SetFloat("AnimMoveX", direction.x);
        _playerAnimator.SetFloat("AnimMoveY", direction.y);
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