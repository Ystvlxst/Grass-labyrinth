using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DistanceToPlayerTransition : Transition
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distance;
    [SerializeField] private bool _less = true;
    
    private Transform _player => _enemy.Player.transform;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NeedTransit = CheckDistance();
    }

    private bool CheckDistance()
    {
        return !(Vector3.Distance(_agent.transform.position, _player.position) <= _distance ^ _less);
    }
}