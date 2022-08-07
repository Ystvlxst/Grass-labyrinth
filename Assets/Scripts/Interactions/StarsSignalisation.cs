using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private FindKeyEffect _findKeyEffect;

    private bool _isShot = true;

    public void TookKey()
    {
        if (_starCounter.CurrentStarsCount != _starCounter.RequireStarsCount)
        {
            _enemyContainer.Signal();
            _findKeyEffect.FindNotAllStars();
        }
        else
        {
            _findKeyEffect.FindAllStars();
        }
    }
}
