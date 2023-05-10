using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera splineCam;
    private SplineTrigger splineTrigger;
    public GameObject trigger;
    public GameObject player;
    public PlayerControls controls;

    private void Awake()
    {
        splineTrigger = trigger.GetComponent<SplineTrigger>();
        controls = player.GetComponent<PlayerControls>();
    }

    private void Start()
    {
        mainCam.enabled = true;
        splineCam.enabled = false;
        controls.playerCam = controls.mainCam;
    }

    private void Update()
    {
        if (splineTrigger.triggered)
        {
            mainCam.enabled = false;
            splineCam.enabled = true;
            controls.playerCam = splineCam;
        }
        else
        {
            mainCam.enabled = true;
            splineCam.enabled = false;
            controls.playerCam = mainCam;
        }
    }
}
