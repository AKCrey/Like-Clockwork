using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketBoots : MonoBehaviour
{
    [Header("Rocket Boots")] public float maxFuel;
    public float thrustForce;
    public float currentFuel;

    public float cooldownTimer = 0f;
    public float rocketBootsCooldown = 0.4f;
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;

    public ThirdPersonController tpController;
    
    void Start()
    {
        _input = GetComponentInChildren<StarterAssetsInputs>();
        _playerInput = GetComponentInChildren<PlayerInput>();
        tpController = GetComponent<ThirdPersonController>();

        currentFuel = maxFuel;
    }
    
    void Update()
    {
        RocketBoot();
    }

    private void RocketBoot()
    {
        if (!tpController.Grounded)
        {
            
            print("NotGrounded");
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= rocketBootsCooldown)
            {
                cooldownTimer = rocketBootsCooldown;
            }
            if (_input.hover > 0.0f && currentFuel > 0f && cooldownTimer>= rocketBootsCooldown)
            {
                print("hover");
                currentFuel -= Time.deltaTime;
                tpController._verticalVelocity = Mathf.Sqrt(thrustForce * -2f * tpController.Gravity);
            }
        }
        else
        {
            cooldownTimer = 0;
            currentFuel = maxFuel;
        }
    }
}

