using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetComponentInParent<SplineScript>()._splineRunning =
                !transform.GetComponentInParent<SplineScript>()._splineRunning;
            Debug.Log("colliding");
        }
    }
}
