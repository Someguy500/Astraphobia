using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//How to Generate Shockingly Good 2D Lightning Effects in Unity (C#) by Aaron Davis
//URL : https://gamedevelopment.tutsplus.com/tutorials/how-to-generate-shockingly-good-2d-lightning-effects-in-unity-c--cms-21275

public class LightningBolt : MonoBehaviour
{
    public GameObject lightningPrefab;
    public List<GameObject> activeSegments;
    public List<GameObject> inactiveSegments;

    public float alpha { get; set; }
    public float fadeSpeed { get; set; }
    public Color tint { get; set; }

    public Vector2 start { get { return activeSegments[0].GetComponent<LightningLine>().start; } }
    public Vector2 end { get { return activeSegments[^1].GetComponent<LightningLine>().end; } }
    
    public bool isComplete { get { return alpha <= 0; } }

    public void Initialize(int maxSegments)
    {
        activeSegments = new List<GameObject>();
        inactiveSegments = new List<GameObject>();

        for (int i = 0; i < maxSegments; i++)
        {
            GameObject segment = (GameObject) Instantiate(lightningPrefab, transform, true);
            segment.SetActive(false);
            inactiveSegments.Add(segment);
        }
    }

    public void ActivateBolt(Vector2 start, Vector2 end, Color c, float thickness)
    {
        tint = c;
        alpha = 1.5f;
        fadeSpeed = 0.03f;
        
        //Create bolt
        if (Vector2.Distance(end, start) <= 0)
        {
            Vector2 adjust = Random.insideUnitCircle;
            if (adjust.magnitude <= 0)
                adjust.x += .1f;
            end += adjust;
        }
        
        //Get direction
        Vector2 slope = end - start;
        Vector2 normal = (new Vector2(slope.y, -slope.x)).normalized;
        
        //Get distance
        float dist = slope.magnitude;

        List<float> positions = new List<float>();
        positions.Add(0);
        
        //Generate bolt segments
        for (int i = 0; i < dist / 4; i++)
            positions.Add(Random.Range(.25f, .75f));
        
        positions.Sort();

        const float sway = 80;
        const float jaggedness = 1 / sway;
        float spread = 1f;

        Vector2 prevPoint = start;
        float prevDisplacement = 0;

        for (int i = 1; i < positions.Count; i++)
        {
            if (inactiveSegments.Count <= 0) break;

            float pos = positions[i];
            float scale = (dist * jaggedness) * (pos - positions[i - 1]); //Prevent sharp angles
            float envelope = (pos > 0.95f) ? 20 * (1 - pos) : spread;

            float displacement = Random.Range(-sway, sway);
            displacement -= (displacement - prevDisplacement) * (1 - scale);
            displacement *= envelope;

            Vector2 point = start + (pos * slope) + (displacement * normal);

            ActivateSegment(prevPoint, point, thickness);
            prevPoint = point;
            prevDisplacement = displacement;
        }

        ActivateSegment(prevPoint, end, thickness);
    }

    public void DeactivateSegment()
    {
        for (int i = activeSegments.Count - 1; i >= 0; i--)
        {
            GameObject segment = activeSegments[i];
            segment.SetActive(false);
            activeSegments.RemoveAt(i);
            inactiveSegments.Add(segment);
        }
    }

    void ActivateSegment(Vector2 start, Vector2 end, float thickness)
    {
        int inactiveCount = inactiveSegments.Count;
        if (inactiveCount <= 0 ) return;

        GameObject segment = inactiveSegments[inactiveCount - 1];
        segment.SetActive(true);

        LightningLine lightComp = segment.GetComponent<LightningLine>();
        lightComp.SetColor(Color.white);
        lightComp.SetLine(start, end, thickness);
        inactiveSegments.RemoveAt(inactiveCount - 1);
        activeSegments.Add(segment);
    }

    public void Draw()
    {
        if (alpha <= 0) return;

        foreach (GameObject segment in activeSegments)
        {
            LightningLine lightComp = segment.GetComponent<LightningLine>();
            lightComp.SetColor(tint * (alpha * 0.6f));
            lightComp.Draw();
        }
    }

    public void UpdateBolt()
    {
        alpha -= fadeSpeed;
    }
}
