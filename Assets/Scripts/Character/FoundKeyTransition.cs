using UnityEngine;

public class FoundKeyTransition : Transition
{
    public void OnFound()
    {
        NeedTransit = true;
    }
}
