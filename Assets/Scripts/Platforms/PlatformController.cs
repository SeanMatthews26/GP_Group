using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 2.0f; // distance platform moves up and down
    public MovementType movementType; // choose the movement to use in the inspector

    private Vector3 initialPosition;
    private float direction = 1.0f; // direction of platform movement (up or down)
    private float angle = 0.0f; // current angle of platform in circle movement
    private const float CIRCLE_RADIUS = 2.0f; // radius of circle for circle movement

    public enum MovementType
    {
        UpDown,
        Circle
    }

    void Start()
    {
        initialPosition = transform.position; // store initial position of platform
    }

    void Update()
    {
        switch (movementType)
        {
            case MovementType.UpDown:
                MoveUpDown();
                break;
            case MovementType.Circle:
                MoveInCircle();
                break;
        }
    }

    private void MoveUpDown()
    {
        // move platform up or down based on current direction
        transform.position += direction * Vector3.up * speed * Time.deltaTime;

        // if platform has moved its maximum distance, switch direction
        if (transform.position.y > initialPosition.y + distance)
        {
            direction = -1.0f;
        }
        else if (transform.position.y < initialPosition.y)
        {
            direction = 1.0f;
        }
    }

    private void MoveInCircle()
    {
        angle += speed * Time.deltaTime; // increase angle based on speed

        // calculate new position based on angle and radius of circle
        float x = initialPosition.x + CIRCLE_RADIUS * Mathf.Cos(angle);
        float z = initialPosition.z + CIRCLE_RADIUS * Mathf.Sin(angle);
        float y = initialPosition.y;

        transform.position = new Vector3(x, y, z);
    }
}

