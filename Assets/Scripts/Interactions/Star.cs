using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private StarCounter _starsCounter;
    [SerializeField] private ParticleSystem _poofEffect;

    private const string _interaction = "Interaction";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(Interact());
            _starsCounter.FindStar();
            _poofEffect.Play();
        }
    }

    private IEnumerator Interact()
    {
        _animator.SetTrigger(_interaction);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
