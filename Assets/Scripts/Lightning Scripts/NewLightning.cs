using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewLightning : MonoBehaviour
{
    private LineRenderer lightning;
    private static int segments = 5;
    
    private float cd;
    private float lightningCd = 1f;
    
    private Vector3[] startPositions = new Vector3[segments];

    void Awake()
    {
        lightning = GetComponent<LineRenderer>();
    }

    void SetPositions()
    {
        lightning.positionCount = segments;
        
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = endPos - startPos;
        Vector2 perpendicular = new Vector2(-dir.y, dir.x);
        
        Vector2 p = startPos + endPos;
        
        Vector2 midpoint = p / 2;
        Vector2 center = midpoint + perpendicular * Random.Range(-0.1f, 0.1f);
        
        for (int i = 1; i < segments - 1; i++)
        {
            Vector2 point = p * i/segments;
            Debug.Log(point);
            Vector2 newPosition = point + perpendicular;
            lightning.SetPosition(i, newPosition);
        }
        
        lightning.SetPosition(0,startPos);
        //lightning.SetPosition(1, center);
        lightning.SetPosition(segments - 1,endPos);   
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
