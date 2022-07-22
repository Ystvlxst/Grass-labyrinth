using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Transform))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Range(0, 360)] private float _viewAngle = 90f;

    [SerializeField] private float _viewDistance = 15f;
    [SerializeField] private float _detectionDistance = 3f;
    [SerializeField] private Transform _player;
    [Header("")]
    [SerializeField] private Transform[] _goals;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private LoseCanvas _loseCanvas;

    private Transform _enemyEye;
    private Transform _agentTransform;
    private NavMeshAgent _agent;
    private int _currentGoal = 0;
    private float _distanceToPlayer;

    public event Action PlayerDetected;
    public event Action LostPlayer;
    public event Action NextGoal;

    private void OnEnable()
    {
        PlayerDetected += OnPlayerDetected;
        LostPlayer += OnPlayerLost;
        NextGoal += OnNextGoal;
    }

    private void OnDisable()
    {
        PlayerDetected -= OnPlayerDetected;
        LostPlayer -= OnPlayerLost;
        NextGoal -= OnNextGoal;
    }

    private void Start()
    {
        _enemyEye = GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();

        _agentTransform = _agent.transform;
        
    }

    private void Update()
    {
        _distanceToPlayer = Vector3.Distance(_player.position, _agent.transform.position);

        _agent.destination = _goals[0].position;

        if (_agent.remainingDistance < _distanceToChangeGoal)
        {
            _currentGoal++;

            if (_currentGoal == _goals.Length)
                _currentGoal = 0;
        }

        DrawViewState();
    }

    private void OnPlayerLost()
    {
        if (_distanceToPlayer <= _detectionDistance || IsInView() == false)
        {

            LostPlayer?.Invoke();
        }
    }

    private void OnPlayerDetected()
    {
        if (_distanceToPlayer <= _detectionDistance || IsInView())
        {
            MoveToPlayer();
            PlayerDetected?.Invoke();
        }
    }

    private void OnNextGoal()
    {
        if (_agent.remainingDistance < _distanceToChangeGoal)
        {
            _currentGoal++;

            if (_currentGoal == _goals.Length)
                _currentGoal = 0;
        }
    }

    private bool IsInView()
    {
        float realAngle = Vector3.Angle(_enemyEye.forward, _player.position - _enemyEye.position);
        RaycastHit hit;

        if(Physics.Raycast(_enemyEye.transform.position, _player.position - _enemyEye.position, out hit, _viewDistance))
        {
            if(realAngle < _viewAngle / 2f && Vector3.Distance(_enemyEye.position, _player.position) <= _viewDistance && hit.transform == _player.transform)
                return true;
        }
        return false;
    }

    private void MoveToPlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void DrawViewState()
    {
        Vector3 left = _enemyEye.position + Quaternion.Euler(new Vector3(0, _viewAngle / 2f, 0)) * (_enemyEye.forward * _viewDistance);
        Vector3 right = _enemyEye.position + Quaternion.Euler(-new Vector3(0, _viewAngle / 2f, 0)) * (_enemyEye.forward * _viewDistance);
        Debug.DrawLine(_enemyEye.position, left, Color.red);
        Debug.DrawLine(_enemyEye.position, right, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
            _loseCanvas.Show();
    }
}