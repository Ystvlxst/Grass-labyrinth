using System.Collections;
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
    private Coroutine _unfreeze;
    private float _speed;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _speed = _agent.speed;
        _agent.destination = _goals[0].position;
    }

    private void Update()
    {
        CheckPlayerDistance();
        CheckNextGoal();
    }

    public void Freeze(float freezeDuration)
    {
        SetSpeed(0);
        
        if(_unfreeze != null)
            StopCoroutine(_unfreeze);
        
        _unfreeze = StartCoroutine(Unfreeze(freezeDuration));
    }

    private IEnumerator Unfreeze(float freezeDuration)
    {
        yield return new WaitForSeconds(freezeDuration);
        SetSpeed(_speed);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            _loseCanvas.Show();
    }

    private bool DetectedPlayer()
    {
        return Vector3.Distance(_agent.transform.position, _player.position) <= _seeDistance;
    }

    private void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
}