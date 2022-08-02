using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _portableObject;
    [SerializeField] private ParticleSystem _findKeyEffect;
    [SerializeField] private StarsSignalisation _starCounter;

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
        _starCounter.AllStarsFound();
    }
}
