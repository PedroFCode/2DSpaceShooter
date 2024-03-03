using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public bool destroyAfterTime = false;

    public void OnTriggerEnter2D(Collider2D whatHitMe){
        if (whatHitMe.gameObject.tag == "Player"){
               FindObjectOfType<GameController>().loseALife();
               Destroy(this.gameObject);
        }
    }
    
}
