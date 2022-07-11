using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraZoomOutTest : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    public Vector3 m_Offset;
    public bool isFullZoom;
    
    public float maxCamSize = 5.0f;
    public float minCamSize = 2.0f;
    public float zoomRate = 1.0f;

    private bool canZoom = true;

    private Vector3 top;
    
    void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0) && canZoom)
        {
            if (cam.m_Lens.OrthographicSize < maxCamSize)
                cam.m_Lens.OrthographicSize += (zoomRate*0.02f);

        }
        else
        {
            if (cam.m_Lens.OrthographicSize > minCamSize)
                cam.m_Lens.OrthographicSize -= (zoomRate*0.05f);

            canZoom = Input.GetAxisRaw("Horizontal") == 0;
        }
        isFullZoom = cam.m_Lens.OrthographicSize >= maxCamSize;
    }
}
