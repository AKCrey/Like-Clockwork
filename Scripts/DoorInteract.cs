using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorInteract : MonoBehaviour, IInteractable
{
    public GameObject target;
    
    public enum PlayerTag
    {
        Player1,
        Player2
    };

    [Header("Can both players interact")]
    public bool bothCanInteract = false;
    private string playerString;
    public Animator _activator;
    [Header("Which player can interact")]
    [SerializeField] private PlayerTag pTag; 
    
    public void Interact(string tag)
    {
        playerString = pTag.ToString();
        

        if (!bothCanInteract)
        {
            if (tag != playerString) return;
            Event();

        }
        else
        {
            Event();
        }
        
    }

    
    private void Event()
    {
        
        print("Open Sesame");
        _activator.SetTrigger("Activated");
        target.GetComponent<ILevelInteraction>().IToggleInteraction();
    }

    
}