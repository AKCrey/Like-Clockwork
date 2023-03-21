using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnRate = 1.0f;

        public bool stunnedAndSmashed = false;
    
        private float spawnRateTimer = 0.0f;
    
        public List<Transform> spawnPositions;
    
        public GameObject obstaclePrefab;

        public Transform spawnPoint;
    
    
        private void CreateObstacleAtSpawnPosition()
        {
            var randomIndex = Random.Range(0, spawnPositions.Count); //Range between 0 to the positions I've put out

            var spawnPoint = spawnPositions[randomIndex]; //gets first position of the list
            
            var obstacleInstance = Instantiate(obstaclePrefab);
            obstacleInstance.transform.position = spawnPoint.position;
        }
    
    
        void Update()
        {
            if (stunnedAndSmashed == false)
            {
                //Timer code
                if (spawnRateTimer > 0.0f) // 1 > 0? 
                {
                    spawnRateTimer -= Time.deltaTime; // 1 - 0.02
                    return;
                }
    
                spawnRateTimer = spawnRate;
    
                //Exhausted timer behavior
                CreateObstacleAtSpawnPosition();
            }
        }
}
