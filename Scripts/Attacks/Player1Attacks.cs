using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Attacks : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField]
    private Transform attackOriginPoint;
    [SerializeField]
    private GameObject lightningPrefab;

    [SerializeField] private Transform attackTarget;
    
    
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;

    [SerializeField]
    private float attackBufferTime = 2f;
    private float attackBuffer;
    private bool attackBool = false;
    
    [SerializeField]
    private LayerMask lm;
    private StarterAssetsInputs _inputs;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponentInChildren<StarterAssetsInputs>();
        _playerInput = GetComponentInChildren<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hitPos;
        if (_input.attack && !attackBool)
        {
            hitPos = attackTarget.position;
            attackBool = true;
            GameObject attack = Instantiate(lightningPrefab, attackOriginPoint.position, attackOriginPoint.rotation) as GameObject;

            LightningScript lightning = attack.GetComponent<LightningScript>();
            lightning.pos = hitPos;
            lightning.attack = true;
            
            //attack.transform.position = Vector3.MoveTowards(attackOriginPoint.position, hitPos, 10*Time.deltaTime);
            _input.attack = false;
        }
        else
        {
            _input.attack = false;
        }

        if (attackBool)
        {
            attackBuffer += Time.deltaTime;
        }

        if (attackBuffer >= attackBufferTime)
        {
            attackBool = false;
            attackBuffer = 0;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackTarget.position, 0.5f);
    }
}
