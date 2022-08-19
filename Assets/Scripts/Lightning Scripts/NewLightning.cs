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

    private Color startColor;
    private Color endColor;
    private float alpha;
    private float alphaDecay = 0.001f;

    void Awake()
    {
        lightning = GetComponent<LineRenderer>();
        startColor = new Color(1,1,1,1);
        endColor = new Color(1,1,1,0);
    }

    void CastLightning()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 slope = endPos - startPos;
        Vector2 normal = new Vector2(-slope.y, slope.x).normalized;

        float dist = slope.magnitude;
        
        Vector2 p = startPos + endPos;
        
        Vector2 midpoint = p / 2;
        Vector2 center = midpoint + normal * Random.Range(-0.1f, 0.1f);

        List<float> positions = new List<float>();
        positions.Add(0);
        
        //Generate bolt segments
        for (int i = 0; i < dist / 4; i++)
            positions.Add(Random.Range(.25f, .75f));
        
        lightning.positionCount = positions.Count + 1;
        
        positions.Sort();

        const float sway = 5;
        const float jaggedness = 0.5f / sway;
        float spread = 1f;
        
        float prevDisplacement = 0;

        for (int i = 1; i < positions.Count; i++)
        {
            float pos = positions[i];
            float scale = (dist * jaggedness) * (pos - positions[i - 1]); //Prevent sharp angles
            float envelope = (pos > 0.95f) ? 20 * (1 - pos) : spread;

            float displacement = Random.Range(-sway, sway);
            displacement -= (displacement - prevDisplacement) * (1 - scale);
            displacement *= envelope;

            Vector2 point = startPos + (pos * slope) + (displacement * normal);

            lightning.SetPosition(i,point);
            prevDisplacement = displacement;
        }
        
        lightning.SetPosition(0,startPos);
        //lightning.SetPosition(1, center);
        lightning.SetPosition(positions.Count,endPos);   
    }
    void Update()
    {
        cd += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Mouse0) && cd >= lightningCd)
        {
            lightning.material.color = startColor;
            CastLightning();
            StartCoroutine(ColorLerp(startColor, endColor, 1));
            cd = 0;
        }
    }

    IEnumerator ColorLerp(Color start, Color end, float t)
    {
        float time = 0;
        while (time < t)
        {
            lightning.material.color = Color.Lerp(start, end, time / t);
            time += Time.deltaTime;
            yield return null;
        }
    }
    
}
