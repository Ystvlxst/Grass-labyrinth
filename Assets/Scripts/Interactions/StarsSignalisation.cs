using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private FindKeyTransition[] _findKeyTransitions;

    public void AllStarsFinded()
    {
        if (_starCounter.CurrentStarsCount == _starCounter.RequireStarsCount)
        {
            foreach(var transition in _findKeyTransitions)
                transition.OnFinded();
        }
        else
            return;
    }
}
