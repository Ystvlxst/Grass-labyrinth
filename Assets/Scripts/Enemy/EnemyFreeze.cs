using System.Collections;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    
    private Coroutine _unfreeze;

    public void Freeze(float freezeDuration)
    {
        _enemyMovement.SetSpeed(0);
        
        if(_unfreeze != null) StopCoroutine(_unfreeze);
        
        _unfreeze = StartCoroutine(Unfreeze(freezeDuration));
    }

    private IEnumerator Unfreeze(float freezeDuration)
    {
        yield return new WaitForSeconds(freezeDuration);
        _enemyMovement.SetSpeed(_enemyMovement.StartSpeed);
    }
}