using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // private
    private bool collided;
    public int switchesPressed = 0;
    private GameObject _player;
    public BoxCollider box;
    private DoorScript doorScript;

    [SerializeField] GameObject door;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        box = this.GetComponent<BoxCollider>();
        doorScript = door.GetComponent<DoorScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction Collider"))
        {
            collided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction Collider"))
        {
            collided = false;
        }
    }

    private void Update()
    {
        if (collided)
        {
            if (_player.GetComponent<PlayerControls>().interacting)
            {
                switchesPressed++;
                box.enabled = false;
                //GameObject door = GameObject.FindGameObjectWithTag("Door");
                if (switchesPressed >= doorScript.requiredSwitches)
                {
                    Debug.Log("hello");
                    door.GetComponent<DoorScript>().opening = true;
                }                
            }
        }
    }
}