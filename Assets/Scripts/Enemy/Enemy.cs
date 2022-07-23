using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _goals;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private Transform _player;
    [SerializeField] private float _seeDistance;
    [SerializeField] private LoseCanvas _loseCanvas;

    private NavMeshAgent _agent;
    private int _currentGoal = 0;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.destination = _goals[0].position;
    }

    private void Update()
    {
        CheckPlayerDistance();
        CheckNextGoal();
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
        else if (DetectedPlayer())
            _agent.SetDestination(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            _loseCanvas.Show();
    }

    public bool DetectedPlayer()
    {
        if (Vector3.Distance(_agent.transform.position, _player.position) <= _seeDistance)
            return true;
        return false;
    }

    public void SpeedMovement(int speed)
    {
        _agent.speed = speed;
    }
}