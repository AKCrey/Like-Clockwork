using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject target;

    
   

    public bool inTrigger = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("InteractTrigger"))
        {
            print("hammertime");
            inTrigger = true;
            target = other.gameObject;
            target.GetComponent<ILevelInteraction>().IToggleInteraction();

        }
        else print("NO_TARGET");
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
