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
    public float powerUpDuration = 10.0f;

    void Start()
    {
        mesh = GetComponent<Mesh>();

        //Check power up to use
        switch (collectableType)
        {
            case CollectableType.coin:
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case CollectableType.doubleJump:
                this.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case CollectableType.speedBoost:
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if it is the player
        if (other.tag == "Player")
        {
            //Collectable disappears
            gameObject.active = false;

            //Pass power up type into PlayerControls
            other.GetComponent<PlayerControls>().ReceiveCollectable(collectableType, powerUpDuration);

            //Disable powerup
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
