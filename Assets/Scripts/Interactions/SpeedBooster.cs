using System.Collections;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _interaction = "Interaction";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            StartCoroutine(Interact());
            playerMovement.ChangeSpeed(2, 10);
        }
    }

    private IEnumerator Interact()
    {
        _animator.SetTrigger(_interaction);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
