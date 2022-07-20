using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _goals;
    [SerializeField] private float distanceToChangeGoal;

    private NavMeshAgent _agent;
    private int currentGoal = 0;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _goals[0].position;
    }

    void Update()
    {
        if (_agent.remainingDistance < distanceToChangeGoal)
        {
            currentGoal++;

            if (currentGoal == _goals.Length) currentGoal = 0;

            _agent.destination = _goals[currentGoal].position;
        }
    }
}