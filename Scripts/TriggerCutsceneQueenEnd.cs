using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;


public class TriggerCutsceneQueenEnd : MonoBehaviour
{
    [Header("BossManager")]
    [SerializeField] private  BossManager _BossManager;

    [Header("Canvas")]
    [SerializeField] private  GameObject canvasPlayer01;
    [SerializeField] private  GameObject canvasPlayer02;
    
    [Header("Camera")]
    [SerializeField] private  GameObject cameraCutsceneQueenStart;

    [Header("Video Player")]
    [SerializeField] private VideoPlayer _VideoPlayerBossEnd;
    
    private void Update()
    {
        if (_BossManager._health <= 0)
        {
            canvasPlayer01.SetActive(false);
            canvasPlayer02.SetActive(false);
            _VideoPlayerBossEnd.Play();
            _VideoPlayerBossEnd.loopPointReached += EndReached;
        }
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
