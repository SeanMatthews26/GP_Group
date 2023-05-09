using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineScript : MonoBehaviour
{
    // public
    public float time;

    // private
    private GameObject _p1;
    private GameObject _p2;
    private GameObject _p3;

    private Vector3 _splinePoint;

    private GameObject _cube;

    public bool _splineRunning;
    void Awake()
    {
        // assign points
        _p1 = transform.GetChild(0).transform.gameObject;
        _p2 = transform.GetChild(1).transform.gameObject;
        _p3 = transform.GetChild(2).transform.gameObject;
        
        _cube = transform.GetChild(3).transform.gameObject;
    }

    Vector3 GetSplinePoint(float t)
    {
        Vector3 p0 = _p1.transform.position;
        Vector3 p1 = _p2.transform.position;
        Vector3 p2 = _p3.transform.position;
        Vector3 p01 = Vector3.Lerp(p0, p1, t);
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
            
        _splinePoint = Vector3.Lerp(p01, p12, t);

        return _splinePoint;
    }

    private void FixedUpdate()
    {
        if (_splineRunning)
        {
            if (time < 0)
            {
                time = 0;
            }

            if (time > 1)
            {
                time = 1;
            }
        
            // Get the current position on the spline
            Vector3 currentPosition = GetSplinePoint(time);

            // Get the next position on the spline to calculate the forward direction
            Vector3 nextPosition = GetSplinePoint(time + Time.fixedDeltaTime);
            Vector3 forwardDirection = nextPosition - currentPosition;
            forwardDirection.Normalize();

            // Set the position and rotation of the cube
            _cube.transform.position = currentPosition + new Vector3(0, 3, 0);
        
            if (time >= 1f)
            {
                _cube.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else
            {
                _cube.transform.rotation = Quaternion.LookRotation(forwardDirection);
            }
        }
    }
    
    public float GetNearestSplineTime(Vector3 position)
    {
        float minDistance = Mathf.Infinity;
        float nearestTime = 0;

        // Check distances from spline points to the given position
        for (float t = 0; t <= 1; t += 0.01f)
        {
            Vector3 splinePoint = GetSplinePoint(t);
            float distance = Vector3.Distance(position, splinePoint);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTime = t;
            }
        }

        return nearestTime;
    }
}
