using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    // private
    private bool opening;


    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (opening)
        {
            GameObject leftPivot = transform.GetChild(0).gameObject;
            GameObject rightPivot = transform.GetChild(1).gameObject;
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if ((leftPivot.transform.localRotation.eulerAngles.y >= 270f) || 
                (leftPivot.transform.localRotation.eulerAngles.y == 0f))
            {
                leftPivot.transform.Rotate(0, -9 * Time.deltaTime, 0, Space.Self);
                rightPivot.transform.Rotate(0, 9 * Time.deltaTime, 0, Space.Self);
                
                player.GetComponent<PlayerControls>().inCutscene = true;
            }

            else
            {
                opening = false;

                // allow player to give input
                player.GetComponent<PlayerControls>().inCutscene = false;
            }
        }
    }

    public void StartOpening()
    {
        if (!opening)
        {
            opening = true;
        }
    }
}
