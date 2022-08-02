using UnityEngine;

public class StarsSignalisation : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private FoundKeyTransition[] _foundKeyTransitions;

    public void AllStarsFound()
    {
        if (_starCounter.CurrentStarsCount == _starCounter.RequireStarsCount)
        {
            foreach(var transition in _foundKeyTransitions)
                transition.OnFound();
        }
    }
}
