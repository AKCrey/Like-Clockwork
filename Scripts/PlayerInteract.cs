using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactDistance = 2f;

    [SerializeField] private Camera _camera;
    [SerializeField]
    private LayerMask _layerMask;

    private RaycastHit hitInfo;

    private string tag;
    [SerializeField]
    private bool hitting = false;
    
    [SerializeField]
    private GameObject playerInteractUI;
    
    //Inputs
    [SerializeField]
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;

    private bool outLine;
    private Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
        tag = gameObject.tag;
        _playerInput = GetComponentInChildren<PlayerInput>();
        _input = GetComponentInChildren<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hitInfo, interactDistance, _layerMask))
        {

            if (hitInfo.collider.CompareTag("Interact"))
            {
                IOnLookInteract hitUI = hitInfo.transform.GetComponent<IOnLookInteract>();

                hitUI?.OnLook(tag);
                
                if (_input.interact)
                {
                    IInteractable hit = hitInfo.transform.GetComponent<IInteractable>();

                    hit?.Interact(tag);
                    _input.interact = false;
                }
            }
            else
            {
                
                playerInteractUI.SetActive(false);
            }
            hitting = true;

        }
        else if(hitting)
        {
            hitting = false;
            playerInteractUI.SetActive(false);

        }
        

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(hitInfo.point, 0.1f);
    }
}
