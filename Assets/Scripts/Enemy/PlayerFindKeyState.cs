using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerFindKeyState : State
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private DistanceToKeySignalTransition _distanceToKeySignalTransition;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_distanceToKeySignalTransition.NeedTransit == true)
            _agent.SetDestination(_player.transform.position);
    }

    private void OnDisable()
    {
        _agent.SetDestination(transform.position);
    }
}
