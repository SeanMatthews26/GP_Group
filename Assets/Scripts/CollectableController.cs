using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    coin,
    doubleJump,
    speedBoost,
    heart
}

public class CollectableController : MonoBehaviour
{
    public CollectableType collectableType = new CollectableType();
    public float powerUpDuration = 2.0f;
    private Vector3 rotation = new Vector3(0, 50, 0);

    void Start()
    {

    }

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if it is the player
        if (other.tag == "Player")
        {
            //Collectable disappears
            gameObject.active = false;

            //Pass power up type into PlayerControls
            other.GetComponent<PlayerControls>().ReceiveCollectable(collectableType);
            other.GetComponent<PlayerControls>().EndPower(collectableType, powerUpDuration);

            //Disable powerup
            //this.GetComponent<BoxCollider>().enabled = false;
            //this.GetComponent<MeshRenderer>().enabled = false;

            if (canRespawn)
            {
                Invoke(nameof(Reset), powerUpDuration);
            }
        }
    }

    public void Reset()
    {
        gameObject.active = true;
    }

    private void Rotate()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
