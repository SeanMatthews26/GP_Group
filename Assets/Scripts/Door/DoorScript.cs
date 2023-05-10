using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // private
    public bool opening;
    public int requiredSwitches;

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (opening)
        {
            gameObject.SetActive(false);
            
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
