using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineTrigger : MonoBehaviour
{
    public bool triggered = false;
    private PlayerControls controls;
    public GameObject player;

    private void Start()
    {
        controls = player.GetComponent<PlayerControls>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
            controls.camEnabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
            controls.camEnabled = true;
        }
    }

    private void Update()
    {
        Debug.Log(triggered);
    }
}
