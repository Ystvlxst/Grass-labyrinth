using UnityEngine;

public class PlayerViewZone : MonoBehaviour
{
    [SerializeField]
    [Range(0, 360)] private float _viewAngle = 90f;

    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private Enemy[] _enemyes;

    private RaycastHit _hit;
    private Ray _ray;
    private float _realAngle;

    private void Update()
    {
        foreach (var enemy in _enemyes)
        {
            _realAngle = Vector3.Angle(transform.forward, enemy.gameObject.transform.position - transform.position);
            _ray = new Ray(transform.position, enemy.transform.position - transform.position);
        }
        Physics.Raycast(_ray, out _hit, _viewDistance);

        CheckEnemyInView();

        Debug.DrawLine(_ray.origin, _hit.point, Color.red);
        DrawViewState();
    }

    private void CheckEnemyInView()
    {
        if(_hit.collider != null)
        {
            foreach (var enemy in _enemyes)
            {
                if(_realAngle < _viewAngle && Vector3.Distance(transform.position, enemy.transform.position) <= _viewDistance && _hit.collider.gameObject == enemy.gameObject && enemy.DetectedPlayer())
                {
                    enemy.SpeedMovement(0);
                    Debug.Log("Попал во врага");
                }
                else
                {
                    enemy.SpeedMovement(4);
                    Debug.Log("Путь к врагу преграждает объект или он слишком далеко");  
                }
            }
        }
    }

    private void DrawViewState()
    {
        Vector3 left = transform.position + Quaternion.Euler(new Vector3(0, _viewAngle / 2f, 0)) * (transform.forward * _viewDistance);
        Vector3 right = transform.position + Quaternion.Euler(-new Vector3(0, _viewAngle / 2f, 0)) * (transform.forward * _viewDistance);
        Debug.DrawLine(transform.position, left, Color.red);
        Debug.DrawLine(transform.position, right, Color.red);
    }
}
