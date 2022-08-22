using UnityEngine;
using UnityEngine.AI;
using Source.EnemyView;

[RequireComponent(typeof(NavMeshAgent))]
public class DistanceToPlayerTransition : Transition
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distance;
    [SerializeField] private bool _less = true;
    [SerializeField] private FieldOfVision _fieldOfVision;
    
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
        return _fieldOfVision.TryFindVisibleTarget(out Player player);
    }
}