using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // private
    private bool collided;

    private GameObject _player;

    [SerializeField] GameObject door;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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
                //GameObject door = GameObject.FindGameObjectWithTag("Door");
                door.GetComponent<DoorScript>().opening = true;
            }
        }
    }
}