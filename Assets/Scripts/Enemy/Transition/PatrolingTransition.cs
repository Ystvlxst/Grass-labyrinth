using UnityEngine;

public class PatrolingTransition : Transition
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distance;

    private Transform _player => _enemy.Player.transform;

    private void Update()
    {
        NeedTransit = CheckDistance();
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(transform.position, _player.position) > _distance;
    }
}