using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 2.0f; // distance platforms move
    public MovementType movementType;
    private Vector3 initialPosition;
    private float direction = 1.0f;
    private float angle = 0.0f; // current angle of platform in circle movement
    private float cirleRadius = 2.0f;
    public GameObject player;
    public bool isOnPlatform = false;
    public bool wasOnPlatform = false;
    private Vector3 keepScale = new Vector3(1.0f, 1.0f, 1.0f);

    public enum MovementType
    {
        // Choose in inspector
        UpDown,
        Circle,
        LeftRight,
        ForwardBackward
    }

    void Start()
    {
        initialPosition = transform.position;
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
            case MovementType.ForwardBackward:
                MoveForwardBackward();
                break;
            case MovementType.LeftRight:
                MoveLeftRight();
                break;
        }

        if (isOnPlatform)
        {
            player.transform.SetParent(this.transform);
            player.transform.localScale = keepScale;
            Debug.Log("Player is child");
        }

        if (!isOnPlatform)
        {
            player.transform.SetParent(null);
        }

        player.transform.localScale = keepScale;
    }

    private void MoveUpDown()
    {
        transform.position += direction * Vector3.up * speed * Time.deltaTime;

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
        float x = initialPosition.x + cirleRadius * Mathf.Cos(angle);
        float z = initialPosition.z + cirleRadius * Mathf.Sin(angle);
        float y = initialPosition.y;

        transform.position = new Vector3(x, y, z);
    }

    private void MoveLeftRight()
    {
        transform.position += direction * Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > initialPosition.x + distance)
        {
            direction = -1.0f;
        }
        else if (transform.position.x < initialPosition.x)
        {
            direction = 1.0f;
        }
    }

    private void MoveForwardBackward()
    {
        transform.position += direction * Vector3.forward * speed * Time.deltaTime;

        if (transform.position.z > initialPosition.z + distance)
        {
            direction = -1.0f;
        }
        else if (transform.position.z < initialPosition.z)
        {
            direction = 1.0f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnPlatform = false;
        }
    }
}