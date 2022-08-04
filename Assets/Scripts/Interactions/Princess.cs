using UnityEngine;

public class Princess : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly  string _dance = "Dance";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.Win();
            _animator.SetTrigger(_dance);
        }
    }
}
