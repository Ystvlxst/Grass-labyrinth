using System.Collections;
using UnityEngine;

public class GrassCutterBooster : MonoBehaviour
{
    [SerializeField] private GameObject _grassBending;
    [SerializeField] private Animator _animator;

    private const string _interaction = "Interaction";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(Interact());
            Boost();
        }
    }

    private IEnumerator Interact()
    {
        _animator.SetTrigger(_interaction);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    private void Boost()
    {
        _grassBending.transform.localScale += new Vector3(1, 1, 1);
    }
}
