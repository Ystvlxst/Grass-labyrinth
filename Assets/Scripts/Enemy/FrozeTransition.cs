using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FrozeTransition : Transition
{
    [SerializeField] private EnemyFreeze _enemyFreeze;
    
    protected override void Enable()
    {
        _enemyFreeze.Froze += OnFroze;
    }

    private void OnDisable()
    {
        _enemyFreeze.Froze -= OnFroze;
    }

    private void OnFroze()
    {
        NeedTransit = true;
    }
}