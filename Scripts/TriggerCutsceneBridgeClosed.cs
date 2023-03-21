using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TriggerCutsceneBridgeClosed : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private  GameObject canvasPlayer01;
    [SerializeField] private  GameObject canvasPlayer02;

    [Header("Camera")]
    [SerializeField] private  GameObject cameraCutsceneBridgeClosed;
    
    [Header("Video Player")]
    [SerializeField] private VideoPlayer _VideoPlayerBridgeClosed;
  
    private void OnTriggerEnter(Collider other)
    {
        canvasPlayer01.SetActive(false);
        canvasPlayer02.SetActive(false);
        _VideoPlayerBridgeClosed.Play();
        _VideoPlayerBridgeClosed.loopPointReached += EndReached;
    }
    
    private void EndReached(VideoPlayer source)
    {
        Debug.Log("end video");
        cameraCutsceneBridgeClosed.SetActive(false);        
        canvasPlayer01.SetActive(true);
        canvasPlayer02.SetActive(true);

        Destroy(gameObject);
    }
}
