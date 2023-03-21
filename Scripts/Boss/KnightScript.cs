using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public Rigidbody rb;
    private bool move;
    private bool isAttacking = false;
    private float speed = 50f;
    private float moveSpeed = 0.5f;
    public Transform[] pos;
    private int index = 0;
    public bool isStunned = false;
    
    void Awake()
    {
        move = false;
        rb = GetComponentInChildren<Rigidbody>();
        rb.isKinematic = false;
        if (!isAttacking)
        {
            StartCoroutine(Knight());
        }
    }

    IEnumerator Knight()
    {
        isAttacking = true;
        yield return new WaitForSeconds(3);
        move = true;
        yield return new WaitForSeconds(moveSpeed);
        move = false;
        index++;
        yield return new WaitForSeconds(moveSpeed);
        move = true;
        yield return new WaitForSeconds(moveSpeed);
        move = false;
        index++;
        yield return new WaitForSeconds(moveSpeed);
        move = true;
        yield return new WaitForSeconds(moveSpeed);
        move = false;
        index++;
        yield return new WaitForSeconds(moveSpeed);
        move = true;
        yield return new WaitForSeconds(moveSpeed);
        move = false;
        index++;
        yield return new WaitForSeconds(moveSpeed);
        Destroy(gameObject);
    }


    private void Update()
    {
        if (move)
        {
            MoveToTarget();
        }
        else
        {
            Drop();
        }
        
    }

    void MoveToTarget()
    {
        rb.isKinematic = true;
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, pos[index].position, speed * Time.deltaTime);
    }

    void Drop()
    {
        rb.AddForce(Vector3.down * (10000 * Time.deltaTime), ForceMode.Acceleration);
        rb.isKinematic = false;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lightning"))
        {
            StopAllCoroutines();
            isStunned = true;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            print("Stunned");
        }
    }
    
}
