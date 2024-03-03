using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] powerUpSpawnPoints;

    [SerializeField]
    private float powerUpSpawnInterval = 2.0f;

    [SerializeField]
    private float powerUpSpawnDelay = 2.0f;

    [SerializeField]
    private PowerUp healPrefab;

    [SerializeField]
    private PowerUp fireRatePrefab;


   public void SpawnPowerUps(){
        InvokeRepeating("SpawnPowerUp", powerUpSpawnDelay, powerUpSpawnInterval);
   }

   void Start(){
        SpawnPowerUps();
   }

   private PowerUp GetPowerUpPrefab(){
        if (Random.value < 0.5f){
            return healPrefab;
          }
        else{
            return fireRatePrefab;
        }
        //return null;
   }

   public void SpawnPowerUp(){
        int randomSpawn = Random.Range(0, powerUpSpawnPoints.Length);
        Debug.Log("PowerUpIndex = " + randomSpawn);
        Transform powerUpSpawnPoint = powerUpSpawnPoints[randomSpawn];
        PowerUp powerUpInstance = Instantiate(GetPowerUpPrefab(), powerUpSpawnPoint.position, powerUpSpawnPoint.rotation);

        if (powerUpInstance.destroyAfterTime){
               Destroy(powerUpInstance.gameObject, 15f);
          }
   }

}


