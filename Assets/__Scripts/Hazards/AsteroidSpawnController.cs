using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnController : MonoBehaviour
{

    [SerializeField]
    private Transform[] asteroidSpawnPoints;

    [SerializeField]
    private float asteroidSpawnInterval = 5.0f;

    [SerializeField]
    private float asteroidSpawnDelay = 2.0f;

    [SerializeField]
    private Asteroid asteroidPrefab;


   public void SpawnAsteroids(){
        InvokeRepeating("SpawnAsteroid", asteroidSpawnDelay, asteroidSpawnInterval);
   }

   void Start(){
        SpawnAsteroids();
   }

   public void SpawnAsteroid(){
        int randomSpawn = Random.Range(0, asteroidSpawnPoints.Length);
        Debug.Log("AsteroidIndex = " + randomSpawn);
        Transform asteroidSpawnPoint = asteroidSpawnPoints[randomSpawn];
        Asteroid asteroidInstance = Instantiate(asteroidPrefab, asteroidSpawnPoint.position, asteroidSpawnPoint.rotation);

        if (asteroidInstance.destroyAfterTime){
               Destroy(asteroidInstance.gameObject, 15f);
          }
   }

}


