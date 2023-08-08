using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _playerAnimator;

    public event Action OnReachDestination;
    public float _angel;

    private Vector2 _targetPosition;
    private bool isTurned;

    public void Initialize()
    {
        OnReachDestination += StopOnReachDestination;
    }

    private void StopOnReachDestination()
    {
        _agent.isStopped = true;
        isTurned = false;
    }

    public void Move(Vector2 position)
    {
        _targetPosition = position;
        _agent.isStopped = false;
        _agent.SetDestination(_targetPosition);
       _angel = Vector2.Angle(_targetPosition, transform.position);
       if ((_angel > 90 || _angel > -90) && !isTurned)
        {
            _playerAnimator.gameObject.transform.localScale *= new Vector2(-1, 1);
            isTurned = false;
        }
        else if (!isTurned)
        {
            _playerAnimator.gameObject.transform.localScale *= new Vector2(-1, 1);
            isTurned = true;   
        }
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