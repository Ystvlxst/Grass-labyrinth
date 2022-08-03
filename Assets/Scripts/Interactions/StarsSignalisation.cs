using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private FoundKeyTransition[] _foundKeyTransitions;
    [SerializeField] private ParticleSystem _findKeyEffectNoAllStars;
    [SerializeField] private ParticleSystem _findKeyEffectAllStars;

    public void TookKey()
    {
        if (_starCounter.CurrentStarsCount != _starCounter.RequireStarsCount)
        {
            foreach (var transition in _foundKeyTransitions)
            {
                transition.OnFound();
                _findKeyEffectNoAllStars.Play();
            }
        }
        else
        {
            _findKeyEffectAllStars.Play();
        }
    }
}
