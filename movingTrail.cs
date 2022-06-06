using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTrail : MonoBehaviour
{
    public GameObject[] points;
    int patrolPointIndex = 0;
    Transform currentPointPosition;
    Vector3 position;
    
    void Start()
    {
        currentPointPosition = points[0].transform;
    }

    
    void Update()
    {
        position = currentPointPosition.position - transform.position;
        transform.Translate(position.normalized * 4f * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, currentPointPosition.position) <= 0.1f)
        {
            nextPoint();
        }
    }

    void nextPoint()
    {
        if (patrolPointIndex >= points.Length -1)
        {
            return;
        }

        patrolPointIndex++;
        currentPointPosition = points[patrolPointIndex].transform;
    }

    
}
