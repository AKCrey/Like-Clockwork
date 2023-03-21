using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    private MeshRenderer playerMesh;

    private DefaultInputActions controls;
    
    private void Awake()
    {
        controls = new DefaultInputActions();
    }

    public void InitialzePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerMesh.material = pc.PlayerMaterial;
        //49.35
    }
}
