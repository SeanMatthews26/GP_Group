using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    private Vector3[] splinePoint;
    private int splinecount;

    public bool drawSpline = true;

    private void Start()
    {
       splinecount = transform.childCount;
        splinePoint = new Vector3[splinecount];

        for (int i = 0; i < splinecount; i++)
        {
            splinePoint[i] = transform.GetChild(i).position;
        }
    }

    private void Update()
    {
        if (splinecount > 1)
        {
            for (int i = 0; i < splinecount - 1; i++)
            {
                Debug.DrawLine(splinePoint[i], splinePoint[i + 1], Color.red);
            }
        }
    }

    public Vector3 WhereOnSpline(Vector3 position)
    {
        int closestSplinePoint = GetClosestPoint(position);

        if (closestSplinePoint == 0)
        {
            return splineSegment(splinePoint[0], splinePoint[1], position);
        }

        else if (closestSplinePoint == splinecount - 1)
        {
            return splineSegment(splinePoint[splinecount - 1], splinePoint[splinecount - 2], position);
        }

        else
        {
            // figures out previous and next point
            Vector3 leftSeg = splineSegment(splinePoint[closestSplinePoint - 1], splinePoint[closestSplinePoint], position);
            Vector3 rightSeg = splineSegment(splinePoint[closestSplinePoint + 1], splinePoint[closestSplinePoint], position);

            if ((position - leftSeg).sqrMagnitude <= (position - rightSeg).sqrMagnitude)
            {
                return leftSeg;
            }
            else
            {
                return rightSeg;
            }
        }
    }

    private int GetClosestPoint(Vector3 position)
    {
        int closestPoint = -1;
        float shortestDistance = 0.0f;

        for (int i = 0; i < splinecount; i++)
        {
            float sqrDistance = (splinePoint[i] - position).sqrMagnitude;
            if (shortestDistance == 0.0f || sqrDistance < shortestDistance)
            {
                shortestDistance = sqrDistance;
                closestPoint = i;
            }
        }
        return closestPoint;
    }

    public Vector3 splineSegment(Vector3 v1, Vector3 v2, Vector3 position)
    {
        Vector3 v1ToPosition = position - v1;
        Vector3 seqDirection = (v2 - v1).normalized;

        float distanceFromV1 = Vector3.Dot(seqDirection, v1ToPosition);

        if (distanceFromV1 < 0.0f)
        {
            return v1;
        }
        else if (distanceFromV1 * distanceFromV1 > (v2 - v1).sqrMagnitude)
        {
            return v2;
        }
        else
        {
            Vector3 fromV1 = seqDirection * distanceFromV1;
            return v1 + fromV1;
        }
    }
}
