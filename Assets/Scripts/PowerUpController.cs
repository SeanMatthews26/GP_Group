using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    doubleJump,
    speedBoost
}

public class PowerUpController : MonoBehaviour
{
    public PowerUpType powerUpType = new PowerUpType();
    public float powerUpDuration = 10.0f;

    void Start()
    {
        //Check power up to use
        switch (powerUpType)
        {
            case PowerUpType.doubleJump:
                this.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case PowerUpType.speedBoost:
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if it is the player
        if (other.tag == "Player")
        {
            //Pass power up type into PlayerControls
            other.GetComponent<PlayerControls>().ReceivePowerUp(powerUpType, powerUpDuration);

            //Disable powerup
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
