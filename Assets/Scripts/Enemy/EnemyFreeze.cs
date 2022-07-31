using System;
using System.Collections;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{
    [SerializeField] private PatrollingState patrollingState;
    
    private Coroutine _unfreeze;

    public event Action Froze;

    public void Freeze(float freezeDuration)
    {
        patrollingState.SetSpeed(0);
        
        if(_unfreeze != null) 
            StopCoroutine(_unfreeze);
        
        _unfreeze = StartCoroutine(Unfreeze(freezeDuration));
        
        Froze?.Invoke();
    }

    private IEnumerator Unfreeze(float freezeDuration)
    {
        yield return new WaitForSeconds(freezeDuration);
        patrollingState.SetSpeed(patrollingState.StartSpeed);
    }
}