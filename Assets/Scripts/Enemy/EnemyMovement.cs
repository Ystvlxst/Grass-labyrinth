using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _goals;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private Transform _player;
    [SerializeField] private float _seeDistance;
    
    private NavMeshAgent _agent;
    private int _currentGoal = 0;
    public float StartSpeed { get; private set; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartSpeed = _agent.speed;
        _agent.destination = _goals[0].position;
    }

    private void Update()
    {
        CheckPlayerDistance();
        CheckNextGoal();
    }

    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }

    private void CheckNextGoal()
    {
        if (_agent.remainingDistance < _distanceToChangeGoal)
        {
            _currentGoal++;

            if (_currentGoal == _goals.Length)
                _currentGoal = 0;
        }
    }

    private void CheckPlayerDistance()
    {
        if (DetectedPlayer() == false)
            _agent.destination = _goals[_currentGoal].position;
        else
            _agent.SetDestination(_player.position);
    }

    private bool DetectedPlayer()
    {
        return Vector3.Distance(_agent.transform.position, _player.position) <= _seeDistance;
    }
}