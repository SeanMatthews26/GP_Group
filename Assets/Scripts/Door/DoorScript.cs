using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // private
    public bool opening;

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (opening)
        {
            GameObject leftPivot = transform.GetChild(0).gameObject;
            GameObject rightPivot = transform.GetChild(1).gameObject;

            if ((leftPivot.transform.eulerAngles.y >= 270f) ||
                (leftPivot.transform.rotation.eulerAngles.y == 0f))
            {
                leftPivot.transform.Rotate(0, -9 * Time.deltaTime, 0, Space.Self);
                rightPivot.transform.Rotate(0, 9 * Time.deltaTime, 0, Space.Self);
            }
            else
            {
                opening = false;
                
                // change camera back
                
                // allow player to give input
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerControls>().inputBlocked = false;
            }
        }
    }

    private void StartOpening()
    {
        if (!opening)
        {
            opening = true;
        }
    }
}
