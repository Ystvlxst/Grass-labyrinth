using UnityEngine;
using Source.EnemyView;

public class PatrolingTransition : Transition
{
    [SerializeField] private FieldOfVision _fieldOfVision;

    private void Update()
    {
        if (_fieldOfVision.TryFindVisibleTarget(out Player player) == false)
            NeedTransit = true;
    }
}   