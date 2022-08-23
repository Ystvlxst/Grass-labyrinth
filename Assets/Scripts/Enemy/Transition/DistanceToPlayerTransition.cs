using UnityEngine;
using UnityEngine.AI;
using Source.EnemyView;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class DistanceToPlayerTransition : Transition
{
    [SerializeField] private bool _notVisible = true;
    [SerializeField] private FieldOfVision _fieldOfVision;
    [SerializeField] private int _timeDelay = 5;

    private Coroutine _coroutine;

    private void Update()
    {
        if (_coroutine == null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Transit(_timeDelay));
    }

    private bool CheckDistance()
    {
        return _fieldOfVision.TryFindVisibleTarget(out Player player);
    }

    private IEnumerator Transit(int time)
    {
        yield return new WaitForSeconds(time);

        if (_notVisible == false)
        {
            NeedTransit = CheckDistance() ^ _notVisible;
            _coroutine = null;
        }
    }
}