using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.5f;

    [SerializeField]
    private float rotationSpeed = 100f;
    
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        float movementX = speed * Time.fixedDeltaTime;
        float movementY = -speed * Time.fixedDeltaTime;
        Vector2 movement = new Vector2(-movementX, movementY);
        rb.MovePosition(rb.position + movement);

        transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
        
    }
}
