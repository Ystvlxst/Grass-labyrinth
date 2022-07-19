using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _portableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            _portableObject.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
