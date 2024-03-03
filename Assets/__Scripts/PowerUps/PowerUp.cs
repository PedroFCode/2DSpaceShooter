using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool destroyAfterTime = false;

    public void OnTriggerEnter2D(Collider2D whatHitMe){
        if (whatHitMe.gameObject.tag == "Player"){
            if(gameObject.name == "Heal(Clone)"){
                Debug.Log("Healed");
                FindObjectOfType<GameController>().gainALife();
                Destroy(this.gameObject);
            }

            if(gameObject.name == "FireRateIncrease(Clone)"){
                Debug.Log("Fire Rate Increased");
                FindObjectOfType<PlayerWeapons>().IncreaseFireRate();
                Destroy(this.gameObject);
            }
            
        }
    }

    
}
