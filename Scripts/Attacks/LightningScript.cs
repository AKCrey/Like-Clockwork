using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private float timer;
    public bool attack = false;
    public Vector3 pos;
    public float speed = 10;

    public GameObject target;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5) 
        {
            DestroyGO();
        }

        /*if (attack)
        {
            Move();
        }*/
        Move();
        
    }

    void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        gameObject.transform.LookAt(pos);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmInteract"))
        {
            print("hammertime");         
            target = other.gameObject;
            target.GetComponent<ILevelInteraction>().IToggleInteraction();

        }
        if (other.CompareTag("Hammer"))
        {
            Destroy(gameObject);

        }

        else print("NO_TARGET");

    }
    public void OnCollisionEnter(Collision collision)
    {
        DestroyGO();
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}
