using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player)) 
            player.Win();
    }
}
