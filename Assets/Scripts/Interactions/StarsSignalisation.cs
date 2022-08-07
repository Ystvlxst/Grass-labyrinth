using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private ParticleSystem _findKeyEffectAllStars;
    [SerializeField] private ParticleSystem _findKeyEffectNoAllStars;
    [SerializeField] private FindKeyEffect _findKeyEffect;

    private bool _isShot = true;

    public void TookKey()
    {
        if (_starCounter.CurrentStarsCount != _starCounter.RequireStarsCount)
        {
            _enemyContainer.Signal();
            _findKeyEffectNoAllStars.Play();
            _findKeyEffect.CheckTimeShot(_isShot);
        }
        else
        {
            _findKeyEffectAllStars.Play();
        }
    }
}
