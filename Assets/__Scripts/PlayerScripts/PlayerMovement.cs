using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float hSpeed = 5.0f;
    [SerializeField]
    private float xBound = 16.0f;
    [SerializeField]
    private float yBound = 7.0f;

    // Update is called once per frame
    void Update()
    {

         float hInput = Input.GetAxis("Horizontal");
         float vInput = Input.GetAxis("Vertical");

         float xOffset = hInput * hSpeed * Time.deltaTime;
         float yOffset = vInput * hSpeed * Time.deltaTime;

         float xPosition = Mathf.Clamp(transform.position.x + xOffset, -xBound, xBound);
         float yPosition = Mathf.Clamp(transform.position.y + yOffset, -yBound, yBound);
         transform.position = new Vector3(xPosition, yPosition, transform.position.z);
        
    }

    
}
