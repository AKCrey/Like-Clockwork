using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public string despawnerTag = "Despawner";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(despawnerTag))
        {
            Destroy(this.gameObject);
        }
    }
}
