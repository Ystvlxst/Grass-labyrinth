using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _animator.SetTrigger("Lose");

        if (other.TryGetComponent(out Princess princess))
            _animator.SetTrigger("Win");
    }
}
