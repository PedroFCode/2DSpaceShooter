using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private int enemyScore;

    public Animator explodeAnimation;

    public AudioSource audioSource;
    public AudioClip explosion;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        explodeAnimation = GetComponent<Animator>(); 
    }

    public void getEnemyScore(string enemyName){
        
        Debug.Log("Enemy Name: " + enemyName);
        
        if (enemyName == "Enemy(Clone)") {
            enemyScore = 50;
        } else if (enemyName == "SeekerEnemy(Clone)") {
            enemyScore = 25;
        } else if (enemyName == "ShieldedEnemy(Clone)") {
            enemyScore = 100;
        } else if (enemyName == "ShootingEnemy(Clone)") {
            enemyScore = 75;
        }
        Debug.Log("Enemy Value: " + enemyScore);

        FindObjectOfType<GameController>().UpdateScorePoints(enemyScore);
    }
    
   public void OnTriggerEnter2D(Collider2D collision){
    Debug.Log("Trigger entered: " + collision.gameObject.name);
    if (collision.gameObject.tag == "Enemy"){
        PlayExplodeSound();
        getEnemyScore(collision.gameObject.name);
        Destroy(this.gameObject);
        }
    else if (collision.gameObject.tag == "Hazard"){
        PlayExplodeSound();
        Destroy(this.gameObject);
        } 
    
 
    }

    void PlayExplodeSound() {
        audioSource.PlayOneShot(explosion);
    }

}
