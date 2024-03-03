using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldedEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.5f;
    private bool hasShield = true;


    [SerializeField]
    private float yOffset = 0.25f;

    [SerializeField]
    private float movementYMultiplier = 1f;

    Rigidbody2D rb;
    float startY;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
    }

    void FixedUpdate(){
        float movementX = speed * Time.fixedDeltaTime;
        float movementY = (Mathf.PingPong(Time.time, yOffset * 2) - yOffset) * movementYMultiplier;
        Vector2 movement = new Vector2(-movementX, movementY);
        rb.MovePosition(rb.position + movement);
    }


    private void OnTriggerEnter2D(Collider2D collision){
        var bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet){
            if(hasShield == true){
                hasShield = false;
            }
            else{
                Destroy(this.gameObject);
                Destroy(bullet.gameObject);
            }     
        }
 
    }
}
