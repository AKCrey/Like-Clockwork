using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerCutsceneStart : MonoBehaviour
{
    public CinemachineVirtualCamera _CinemachineCutsceneBossStart;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("StartCut");
        _CinemachineCutsceneBossStart.m_Priority = 20;
    }
}
