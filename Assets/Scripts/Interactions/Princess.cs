using UnityEngine;

public class Princess : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] StarCounter _flowerCounter;

    private readonly  string _dance = "Dance";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.Win();
            Reaction(_flowerCounter.CurrentStarsCount.ToString());
        }
    }

    private void Reaction(string flowersCount)
    {
        _animator.SetTrigger(flowersCount);
    }
}
