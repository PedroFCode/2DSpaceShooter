using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D whatHitMe){
        var bullet = whatHitMe.gameObject.GetComponent<Bullet>();
        if (bullet){
            Destroy(this.gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
