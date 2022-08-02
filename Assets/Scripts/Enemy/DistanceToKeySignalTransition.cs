using UnityEngine;

public class DistanceToKeySignalTransition : Transition
{
    [SerializeField] private GameObject _key;

    private void Update()
    {
        CheckKeyActive();
    }

    private void CheckKeyActive()
    {
        if (_key.activeSelf == false)
            NeedTransit = true;
    }
}
