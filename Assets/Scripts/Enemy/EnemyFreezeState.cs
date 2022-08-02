using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFreezeState : State
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    
    private float _startSpeed;

    public event Action Froze;

    private void Awake()
    {
        _startSpeed = _navMeshAgent.speed;
    }

    public void OnEnable()
    {
        _navMeshAgent.speed = 0;
        
        Froze?.Invoke();
    }

    private void OnDisable()
    {
        _navMeshAgent.speed = _startSpeed;
    }
}