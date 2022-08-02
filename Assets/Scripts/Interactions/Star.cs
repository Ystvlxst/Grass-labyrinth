using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private StarCounter _starsCounter;

    private const string _interaction = "Interaction";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(Interact());
            _starsCounter.FindStar();
        }
    }

    private IEnumerator Interact()
    {
        _animator.SetTrigger(_interaction);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
