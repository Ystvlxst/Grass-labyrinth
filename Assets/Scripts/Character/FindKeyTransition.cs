using UnityEngine;

public class FindKeyTransition : Transition
{
    public void OnFinded()
    {
        NeedTransit = true;
    }
}
