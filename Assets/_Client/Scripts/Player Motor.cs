using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Vector2 _tagetPosition;

    public NavMeshAgent Agent => _agent;

    public void Initialize()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void Move(Vector2 position)
    {
        _tagetPosition = position;
        _agent.isStopped = false;
        _agent.SetDestination(_tagetPosition);
    }

    public void TeleportToPoint(Vector2 position)
    {
        _agent.enabled = false;
        transform.position = position;
        _agent.enabled = true;
    }

    private void Update()
    {
        if (St)
        {
            _agent.isStopped = true;
        }
    }

    public bool St => Vector2.Distance(transform.position, _tagetPosition) <= _agent.stoppingDistance;

    public bool IsMoving() => _agent.isStopped;
}
