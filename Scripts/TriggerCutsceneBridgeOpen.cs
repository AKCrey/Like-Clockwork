using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TriggerCutsceneBridgeOpen : MonoBehaviour
{
    [Header("DrawBridgeManager")]
    private  DrawBridgeActivate _drawBridgeManager;

    [Header("Canvas")]
    [SerializeField] private  GameObject canvasPlayer01;
    [SerializeField] private  GameObject canvasPlayer02;

    [Header("Camera")]
    [SerializeField] private  GameObject cameraCutsceneBridgeOpen;
    
    [Header("Video Player")]
    [SerializeField] private VideoPlayer _VideoPlayerBridgeOpen;
  
    private void Update()
    {
        Debug.Log(_drawBridgeManager.isTripped.ToString());
        
        if (_drawBridgeManager.isTripped)
        {
            canvasPlayer01.SetActive(false);
            canvasPlayer02.SetActive(false);
            _VideoPlayerBridgeOpen.Play();
            _VideoPlayerBridgeOpen.loopPointReached += EndReached;
            
        }
    }

    private void EndReached(VideoPlayer source)
    {
        Debug.Log("end video");
        cameraCutsceneBridgeOpen.SetActive(false);        
        canvasPlayer01.SetActive(true);
        canvasPlayer02.SetActive(true);

        Destroy(gameObject);
    }
}
