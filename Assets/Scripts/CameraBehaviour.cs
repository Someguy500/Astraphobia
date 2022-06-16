using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform trackedObject;
    public float updateSpeed = 10f;
    public Vector2 trackingOffset;
    private Vector3 offset;

    public Camera cam;
    public float defaultZoom = 2f;
    public float maxZoom = 5f;
    public float zoomSpeed = 10f;
    private float targetZoom;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    
    //Test
    
    //(Below was an attempt to change orthographicSize in the main camera, but i didn't realize we were using CM vcam1)
    /*void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (cam.orthographicSize < 5)
            {
                cam.orthographicSize = cam.orthographicSize + 0.01f;
            }
        }
        else
        {
            if (cam.orthographicSize > 2)
            {
                cam.orthographicSize = cam.orthographicSize - 0.01f;
            }
        }
    }*/
    
    void LateUpdate()
    {
        // //Tracking Player  - No longer used, swapped to CineMachine
        // offset = (Vector3)trackingOffset;
        // offset.z = transform.position.z - trackedObject.position.z;
        // transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + offset,
        //     updateSpeed * Time.deltaTime);
        
        
    }
}
