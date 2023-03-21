using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour, IInteractable
{
    private HashSet<int> ids = new HashSet<int>();
    public void Interact(string tag)
    {
        MOtherScript(this.gameObject.GetInstanceID());
    }

    public void MOtherScript(int id)
    {
        if (!ids.Contains(id))
        {
            ids.Add(id);
        }
    }
}
