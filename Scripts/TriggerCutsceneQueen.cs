using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TriggerCutsceneQueen : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private  GameObject canvasPlayer01;
    [SerializeField] private  GameObject canvasPlayer02;

    [Header("Camera")]
    [SerializeField] private  GameObject cameraCutsceneQueenStart;
    
    [Header("Video Player")]
    [SerializeField] private VideoPlayer _VideoPlayerQueenStart;
  
    private void OnTriggerEnter(Collider other)
    {
        canvasPlayer01.SetActive(false);
        canvasPlayer02.SetActive(false);
        _VideoPlayerQueenStart.Play();
        _VideoPlayerQueenStart.loopPointReached += EndReached;
    }
    
    private void EndReached(VideoPlayer source)
    {
        Debug.Log("end video");
        cameraCutsceneQueenStart.SetActive(false);        
        canvasPlayer01.SetActive(true);
        canvasPlayer02.SetActive(true);

        Destroy(gameObject);
    }
}
