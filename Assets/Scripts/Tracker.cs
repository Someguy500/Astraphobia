using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform trackedObject;
    public float updateSpeed = 10f;
    public Vector2 trackingOffset;
    private Vector3 offset;

    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackedObject.position.z;
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + offset,
            updateSpeed * Time.deltaTime);
    }
}
