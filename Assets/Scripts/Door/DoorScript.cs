using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // private
    public bool opening;
    public int requiredSwitches;


    void Update()
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

    public void StartOpening()
    {
        if (!opening)
        {
            opening = true;
        }
    }
}
