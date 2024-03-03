using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float speed = 5.0f;

    private bool touchStart = false;
    private Vector2 posA;
    private Vector2 posB;

    public Transform innerCircle;
    public Transform outerCircle;

    // The distance threshold for operating the joystick
    public float distanceThreshold = 50.0f;

    void Start()
    {
        // Set the joystick position to the bottom left corner of the screen
        posA = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.1f, Screen.height * 0.2f, Camera.main.transform.position.z));
        innerCircle.position = posA;
        outerCircle.position = posA;
        innerCircle.GetComponent<SpriteRenderer>().enabled = true;
        outerCircle.GetComponent<SpriteRenderer>().enabled = true;
    }

   void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Vector2 clickPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        float distance = Vector2.Distance(clickPos, innerCircle.position);
        if (distance < distanceThreshold)
        {
            touchStart = true;
            posA = innerCircle.position;
        }
    }
    else if (Input.GetMouseButton(0) && touchStart)
    {
        posB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }
    else
    {
        touchStart = false;
        innerCircle.transform.position = posA;
    }

    // Check if the mouse click position is within the bounds of the joystick
    if (touchStart)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }
}

    void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = posB - posA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            movePlayer(direction);

            innerCircle.transform.position = new Vector2(posA.x + direction.x, posA.y + direction.y);
        }
    }

    void movePlayer(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
