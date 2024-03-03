using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemySpawnPoints;

    [SerializeField]
    private float spawnInterval = 5.0f;

    [SerializeField]
    private float spawnDelay = 2.0f;

    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private Enemy seekerEnemyPrefab;

    [SerializeField]
    private Enemy shieldedEnemyPrefab;

    [SerializeField]
    private Enemy shooterEnemyPrefab;

    //private Dictionary<string, (Enemy, Enemy)> levelEnemyPrefabs;

    Scene activeScene;

   // private Coroutine spawnRateCoroutine;

    private Enemy GetEnemyPrefab()
    {
          
     //Tutorial
     if (activeScene.name == "Tutorial"){
          return enemyPrefab;
     }

     //Level_1  
     if(activeScene.name == "Level_1"){
          if (Random.value < 0.5f){
               return enemyPrefab;
          }
          else{
               return seekerEnemyPrefab;
          }
     }

        //Level_2  
     if(activeScene.name == "Level_2"){
          float randomValue = Random.value;
          if (randomValue < 0.33f){
               return enemyPrefab;
          }
          else if (randomValue < 0.67f){
               return seekerEnemyPrefab;
          }
          else{
               return shieldedEnemyPrefab;
          }
     }

          //Level_3
     if(activeScene.name == "Level_3"){
          float randomValue = Random.value;
          if (randomValue < 0.25f){
               return enemyPrefab;
          }
          else if (randomValue < 0.50f){
               return seekerEnemyPrefab;
          }
          else if (randomValue < 0.75f){
               return shieldedEnemyPrefab;
          }
          else{
               return shooterEnemyPrefab;
          }
     }

          //Endless Mode
     if(activeScene.name == "Endless"){
          float randomValue = Random.value;
          if (randomValue < 0.25f){
               return enemyPrefab;
          }
          else if (randomValue < 0.50f){
               return seekerEnemyPrefab;
          }
          else if (randomValue < 0.75f){
               return shieldedEnemyPrefab;
          }
          else{
               return shooterEnemyPrefab;
          }
               
     }

     else{
          return null;
     }
    }

    public void SpawnEnemyWaves(){
     InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    void Start(){
        

     activeScene = SceneManager.GetActiveScene();

     // if(activeScene.name == "Endless"){
     //    spawnRateCoroutine = StartCoroutine(IncreaseSpawnRate());
     // }

     SpawnEnemyWaves();
        
    }

//     private IEnumerator IncreaseSpawnRate(){
//      while (true)
//      {
//         yield return new WaitForSeconds(2f);
//         spawnInterval -= 0.1f;
//         if(spawnInterval <= 0.1){
//           StopCoroutine(spawnRateCoroutine);
//         }
//         else{
//           CancelInvoke("SpawnEnemy");
//           InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
//         }
//       }
    
//     }


    public void SpawnEnemy(){
     int randomSpawn = Random.Range(0, enemySpawnPoints.Length);
     Debug.Log("Index = " + randomSpawn);
     Transform enemySpawnPoint = enemySpawnPoints[randomSpawn];
     Enemy enemyInstance = Instantiate(GetEnemyPrefab(), enemySpawnPoint.position, enemySpawnPoint.rotation);
     
     if (enemyInstance.destroyAfterTime){
          Destroy(enemyInstance.gameObject, 10f);
     }
    }
}
