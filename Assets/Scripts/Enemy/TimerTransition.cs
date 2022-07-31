using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TimerTransition : Transition
{
    [SerializeField] private float _time;
    
    protected override void Enable()
    {
        Invoke(nameof(Transit), _time);
    }

    public void Transit()
    {
        NeedTransit = true;
    }
}