using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRespawn : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;
   
  
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Death"))
      {
         Destroy(other.gameObject);
         Instantiate(enemyPrefab);
         
      }
   }

  
}
