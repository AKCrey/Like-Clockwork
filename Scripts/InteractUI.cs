using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour, IOnLookInteract
{
    public enum PlayerTag
    {
        Player1,
        Player2
    };
    
    [SerializeField]
    private GameObject p1InteractUI;
    [SerializeField]
    private GameObject p2InteractUI;
    
    [Header("Can both players interact")]
    public bool bothCanInteract = false;
    private string playerString;
    [Header("Which player can interact")]
    public PlayerTag pTag = new PlayerTag();
    

    public void OnLook(string tag)
    {
        playerString = pTag.ToString();

        if (!bothCanInteract)
        {
            if (tag != playerString) return;
            if (tag == "Player1")
            {
                P1EnableUI();
            }
            else
            {
                P2EnableUI();
            }
        }
        else
        {
            if (tag == "Player1")
            {
                P1EnableUI();
            }
            else
            {
                P2EnableUI();
            }
        }
        
        

    }
    
    private void P1EnableUI()
    {
        p1InteractUI.SetActive(true);

    }
    private void P2EnableUI()
    {
        p2InteractUI.SetActive(true);

    }

}
