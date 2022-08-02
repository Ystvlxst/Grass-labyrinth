using UnityEngine;

public class DistanceToKeySignalTransition : Transition
{
    [SerializeField] private GameObject _key;

    private void Update()
    {
        NeedTransit = CheckKeyActive();
    }

    private bool CheckKeyActive()
    {
        return _key.activeSelf == false;
    }
}
