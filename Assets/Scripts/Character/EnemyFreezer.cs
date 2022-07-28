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
            if (_fieldOfVision.TryFindVisibleTarget(out EnemyFreeze enemyFreeze))
                enemyFreeze.Freeze(_freezeDuration);
            
            yield return new WaitForSeconds(_delayBetweenFreeze);
        }
    }
}