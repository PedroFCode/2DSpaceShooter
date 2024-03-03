using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 7.5f;
    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        float movement = speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + Vector2.left * movement);
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if(bullet){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
        
    }
}
