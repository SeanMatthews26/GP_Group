using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSplineTrigger : MonoBehaviour
{
    public Camera mainCam;
    public Camera splineCam;

    private void Start()
    {
        mainCam.enabled = true;
        splineCam.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splineCam.enabled = true;
            mainCam.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splineCam.enabled = false;
            mainCam.enabled = true;
        }
    }
}
