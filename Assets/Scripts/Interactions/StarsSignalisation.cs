using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private EnemyContainer _enemyContainer;

    public void TookKey()
    {
        if (_starCounter.CurrentStarsCount != _starCounter.RequireStarsCount)
        {
            _enemyContainer.Signal();
        }
    }
}
