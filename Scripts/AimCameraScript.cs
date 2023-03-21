using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AimCameraScript : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 0.5f;
    public Transform t_player;
    private CharacterController cc;
    float xRotation = 0f;
    float yRotation = 0f;

    private CinemachineVirtualCamera vcam;

    private Vector2 mouseLook;
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ThirdPersonController tpc;
    [SerializeField] private GameObject crosshair;

    private bool isCurrentDeviceMouse;
    
    // Start is called before the first frame update
    void Start()
    {
        crosshair.SetActive(false);
        tpc.enabled = true;
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Priority = 0;
        cc = t_player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isCurrentDeviceMouse = tpc.IsCurrentDeviceMouse;

        if (_input.aim)
        {
            if (isCurrentDeviceMouse)
            {
                Aim();
            }
            else
            {
                CameraAim(); 
            }
            
        }
        else
        {
            vcam.Priority = 0;
            crosshair.SetActive(false);
            tpc.isAiming = false;
        }
    }


    void CameraAim()
    {
        //cc.enabled = false;
        vcam.Priority = 20;
        //tpc.enabled = false;
        crosshair.SetActive(true);
        float mouseX = 0;
        float mouseY = 0;
        tpc.isAiming = true;
        
        mouseX += _input.look.x * mouseSensitivity * Time.deltaTime;
        mouseY += -_input.look.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -15f, 20f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        t_player.Rotate(Vector3.up * mouseX);
    }

    void Aim()
    {
        //cc.enabled = false;
        crosshair.SetActive(true);
        tpc.isAiming = true;
        vcam.Priority = 20;
        //tpc.enabled = false;
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        crosshair.SetActive(true);
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -15f, 20f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        t_player.Rotate(Vector3.up * mouseX);

    }
    
}
