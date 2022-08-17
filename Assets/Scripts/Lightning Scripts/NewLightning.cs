using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLightning : MonoBehaviour
{
    private LineRenderer lightning;
    private static int length = 10;
    private float r;
    private float rMax = 1f;

    private float cd;
    private float lightningCd = 1f;
    
    private Vector3[] startPositions = new Vector3[length];

    void Awake()
    {
        lightning = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lightning.GetPositions(startPositions);
    }

    void GetPositions()
    {
        lightning.GetPositions(startPositions);
    }

    void SetPositions()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector2(temp.x, temp.y);
        
        lightning.SetPosition(0,transform.position);
        lightning.SetPosition(1,pos);   
    }
    void Update()
    {
        cd += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Mouse0) && cd >= lightningCd)
        {
            SetPositions();
            cd = 0;
        }
    }
}
