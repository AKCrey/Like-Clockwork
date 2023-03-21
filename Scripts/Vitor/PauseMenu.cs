using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsRunning;

    public GameObject pauseMenuUI;
    private StarterAssetsInputs _input;
    private PlayerInput _playerInput;
    [SerializeField] public GameObject test;
    public GameObject pauseFirstButton;


    public void Start()
    {
        _input = test.GetComponentInChildren<StarterAssetsInputs>();
        _playerInput = GetComponentInChildren<PlayerInput>();
        gameIsRunning = true;

    }

    public void Update()
    {
        if (_input.pause)
        {
            Pause();
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        // ResumeTrigger();
        Debug.Log("im trying to resume here!");


    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        _input.pause = false;
       // EventSystem.current.SetSelectedGameObject(null);  
       // EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        Debug.Log("am i pausing too much?");




    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
    
  
    

}
