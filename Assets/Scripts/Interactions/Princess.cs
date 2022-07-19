using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    [SerializeField] private WinCanvas _winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            _winCanvas.Show();
        }
    }
}
