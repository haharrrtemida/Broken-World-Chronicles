using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;   

    public void Initialize()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void Move(Vector2 position)
    {
        _agent.SetDestination(position);
    }
}
