using System.Collections;
using Source.EnemyView;
using UnityEngine;

public class EnemyFreezer : MonoBehaviour
{
    [SerializeField] private FieldOfVision _fieldOfVision;
    [SerializeField] private float _freezeDuration = 1f;
    [SerializeField] private float _delayBetweenFreeze = 0.1f;

    private void Start()
    {
        StartCoroutine(Freeze());
    }

    private IEnumerator Freeze()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayBetweenFreeze);

            if (_fieldOfVision.TryFindVisibleTarget(out Enemy enemy))
                enemy.Freeze(_freezeDuration);
        }
    }
}