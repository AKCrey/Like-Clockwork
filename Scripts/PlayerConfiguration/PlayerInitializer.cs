using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private PlayerInput characterOne;
    [SerializeField] private PlayerInput characterTwo;

    private void Start()
    {
        PlayerConfigurationManager pcm = PlayerConfigurationManager.Instance;
        if (!pcm)
        {
            Debug.LogWarning("No PlayerConfigurationManager found in scene.");
            return;
        }
        SetCharacter(pcm);
    }

    public void SetCharacter(PlayerConfigurationManager pcm)
    {
        PlayerConfiguration[] pConfig = pcm.GetPlayerConfigs();

        foreach (PlayerConfiguration config in pConfig)
        {
            config.Input.notificationBehavior = PlayerNotifications.SendMessages;
            switch (config.characterIndex)
            {
                case 0:
                    characterOne = config.Input; break;
                case 1:
                    characterTwo = config.Input; break;
            }
        }
    }
}
