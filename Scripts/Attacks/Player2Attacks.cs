using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Attacks : MonoBehaviour
{
    [SerializeField]
    private GameObject attackOriginPoint;
    
    [SerializeField]
    private float attackBufferTime = 2f;
    private float attackBuffer;
    private bool attackBool = false;
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;
    private CharacterController cc;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        attackOriginPoint.SetActive(false);
        cc = GetComponentInChildren<CharacterController>();
        cc.enabled = true;
        _input = GetComponentInChildren<StarterAssetsInputs>();
        _playerInput = GetComponentInChildren<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_input.attack && !attackBool)
        {
            _input.attack = false;
            _animator.SetTrigger("HammerTime");
            StartCoroutine("Trigger");
            
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

    IEnumerator Trigger()
    {
        cc.enabled = false;
        yield return new WaitForSeconds(0.5f);
        attackOriginPoint.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        cc.enabled = true;
        attackOriginPoint.SetActive(false);
        
    }
    
}

