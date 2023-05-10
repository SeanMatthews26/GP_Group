using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMover : MonoBehaviour
{
    public Spline spline;
    public Transform playerTransform;
    private Transform moverTransform;

    private void Start()
    {
        moverTransform = transform;
    }

    private void Update()
    {
        moverTransform.position = spline.WhereOnSpline(playerTransform.position);
    }

}
