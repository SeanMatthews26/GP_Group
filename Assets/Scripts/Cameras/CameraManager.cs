using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera splineCam;

    private void Start()
    {
        mainCam.enabled = true;
        splineCam.enabled = true;
    }
}
