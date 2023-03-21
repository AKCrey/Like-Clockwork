using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RookScript : MonoBehaviour
{
    //private BossManager BM;
    [SerializeField]
    private float time = 0f;
    private Rigidbody rb;
    private float speed = 50f;
    private bool isAttacking = false;
    private bool addForce = true;
    public Collider triggerCollider;
    private bool isStunned = false;
    public int attackTimes = 0;
    private void Awake()
    {
        triggerCollider.enabled = true;
        rb = GetComponent<Rigidbody>();
        time = BossManager.BM.attackTime;
        rb.AddForce(Vector3.down * (10000 * Time.deltaTime), ForceMode.Acceleration);
        if (!isAttacking)
        {
            StartCoroutine(Attack());
        }
        
    }

    private void Update()
    {
        if (addForce)
        {
            rb.AddForce(Vector3.down * (10000 * Time.deltaTime), ForceMode.Acceleration);
        }

        if (attackTimes >= 6)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Attack()
    {
        rb.isKinematic = false;
        isAttacking = true;
        yield return new WaitForSeconds(time*0.5f);
        addForce = false;
        yield return new WaitForSeconds(time*0.5f);
        rb.velocity = (-rb.transform.right) * speed;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lightning"))
        {
            triggerCollider.enabled = false;
            isStunned = true;
            //rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            //rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            print("Stunned");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            print("Damage");
            attackTimes++;
            BossManager.BM.Damage();
        }
    }
}
