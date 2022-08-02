using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _portableObject;
    [SerializeField] private ParticleSystem _findKeyEffect;
    [SerializeField] private StarsSignalisation _signalisation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            FindKey();
    }

    private void FindKey()
    {
        _portableObject.gameObject.SetActive(true);
        gameObject.SetActive(false);
        _findKeyEffect.Play();
        _signalisation.TookKey();
    }
}
