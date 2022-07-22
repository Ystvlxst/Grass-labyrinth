using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerViewZone : MonoBehaviour
{
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private Enemy[] _enemyes;

    private Transform _player;
    private RaycastHit _hit;

    private void Start()
    {
        _player = GetComponent<Transform>();
    }

    private void Update()
    {
        CheckEnemyInView();
    }

    private void CheckEnemyInView()
    {
        foreach(var enemy in _enemyes)
        {
            if (Physics.Raycast(_player.transform.position, enemy.gameObject.transform.position - _player.position, out _hit, _viewDistance))
            {
                if (Vector3.Distance(_player.position, enemy.gameObject.transform.position) <= _viewDistance && _hit.transform == enemy.transform)
                    enemy.SpeedMovement(0);
                else
                    enemy.SpeedMovement(4);
            }
        }
    }
}
