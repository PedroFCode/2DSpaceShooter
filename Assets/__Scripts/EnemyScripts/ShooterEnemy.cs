using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float stoppingDistance;

    [SerializeField]
    private float backingDistance;

    private float timeBetweenShots;

    [SerializeField]
    private float startTimeBetweenShots;

    [SerializeField]
    private EnemyBullet enemyBullet;

    private Transform player;

    private SpriteRenderer spriteRenderer;

    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        timeBetweenShots = startTimeBetweenShots;
    }

    
    void Update(){
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //Debug.Log("Moving");
        }
        else if(Vector2.Distance(transform.position, player.position) <= stoppingDistance && Vector2.Distance(transform.position, player.position) > backingDistance){
            transform.position = this.transform.position;
            //Debug.Log("Stopped");
        }
        else if(Vector2.Distance(transform.position, player.position) < backingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            //Debug.Log("Moving Away");
        }

        if(timeBetweenShots <= 0){
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }else{
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void FixedUpdate(){
        if (transform.position.x < player.position.x){
            spriteRenderer.flipX = false;
        }
        else{
            spriteRenderer.flipX = true;
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
