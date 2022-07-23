using UnityEngine;

public class PlayerViewZone : MonoBehaviour
{
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private Enemy[] _enemyes;

    private RaycastHit _hit;
    private Ray _ray;

    private void Update()
    {
        foreach (var enemy in _enemyes)
            _ray = new Ray(transform.position, enemy.transform.position - transform.position);
        Physics.Raycast(_ray, out _hit);

        CheckEnemyInView();

        Debug.DrawLine(_ray.origin, _hit.point, Color.red);
    }

    private void CheckEnemyInView()
    {
        if(_hit.collider != null)
        {
            foreach (var enemy in _enemyes)
            {
                if(_hit.collider.gameObject == enemy.gameObject && Vector3.Distance(transform.position, enemy.transform.position) <= _viewDistance)
                {
                    Debug.Log("Попал во врага");

                    if (enemy.DetectedPlayer())
                        enemy.SpeedMovement(0);
                }
                else
                {
                    Debug.Log("Путь к врагу преграждает объект или он слишком далеко");

                    if (enemy.DetectedPlayer() == false)
                        enemy.SpeedMovement(4);
                }
            }
        }
    }
}
