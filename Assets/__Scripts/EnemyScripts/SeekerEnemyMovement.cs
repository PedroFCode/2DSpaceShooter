using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.5f;

    private Transform player;
    private Rigidbody2D rb;
    
    private SpriteRenderer spriteRenderer;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        float movement = speed * Time.fixedDeltaTime;
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * movement);

        // Check if the sprite needs to be flipped
        if (transform.position.x < player.position.x){
            spriteRenderer.flipX = true;
        }
        else{
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        var bullet = collision.gameObject.GetComponent<Bullet>();
    
        if (bullet){
            Destroy(this.gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
