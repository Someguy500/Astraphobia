using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoomOutTest : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public float maxCamSize = 5.0f;
    public float minCamSize = 2.0f;
    public float zoomRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)&&cam.m_Lens.OrthographicSize < maxCamSize)
        {
            cam.m_Lens.OrthographicSize = cam.m_Lens.OrthographicSize + (zoomRate*0.01f);
        }
        else if (cam.m_Lens.OrthographicSize > minCamSize)
        {
            cam.m_Lens.OrthographicSize = cam.m_Lens.OrthographicSize - (zoomRate*0.01f);
        }
    }
}
