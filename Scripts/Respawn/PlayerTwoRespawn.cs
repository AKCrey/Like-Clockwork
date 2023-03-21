using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoRespawn : MonoBehaviour
{
    public Transform _currentCheckpoint; //Storing last checkpoint here
    public AudioManager AudioManager;
    public GameObject DeathCanvas;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            if (_currentCheckpoint != null)
            {
                _currentCheckpoint.gameObject.SetActive(false);
            }
            _currentCheckpoint = collision.transform;
            Debug.Log("New checkpoint \n");
        }
        if (collision.transform.CompareTag("Death"))
        {
            print("Death");
            AudioManager.Play("PlayerDeath");
            DeathCanvas.SetActive(true);
            StartCoroutine(Respawn());
        }

        
    }

    public IEnumerator Respawn()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = _currentCheckpoint.position; //Move player to position.
        yield return new WaitForSeconds(1f);
        DeathCanvas.SetActive(false);
        GetComponent<CharacterController>().enabled = true;

    }
    
   
}