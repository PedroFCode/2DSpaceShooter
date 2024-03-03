using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform player;
    private Vector2 target;
    private Vector2 moveDirection;


    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        moveDirection = (target - (Vector2)transform.position).normalized;
    }

    
    void Update(){
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target) <= 0.1f){
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        }

        if(transform.position.x == target.x && transform.position.y == target.y){
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){

    if (collision.gameObject.tag == "Player"){
             FindObjectOfType<GameController>().loseALife();
             Destroy(this.gameObject);
        }
    if (collision.gameObject.tag == "Hazard"){
             Destroy(this.gameObject);
        }    
   }
}
