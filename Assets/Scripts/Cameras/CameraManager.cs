using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera splineCam;
    public GameObject splineTriggerBox;
    private SplineTrigger splineTrigger;

    private void Awake()
    {
        splineTrigger = splineTriggerBox.GetComponent<SplineTrigger>();
    }

    private void Start()
    {
        mainCam.enabled = true;
        splineCam.enabled = false;
    }

    private void Update()
    {
        if(splineTrigger.triggered)
        {
            mainCam.enabled = false;
            splineCam.enabled = true;
        }
        else
        {
            mainCam.enabled = true;
            splineCam.enabled = false;
        }
    }
}
