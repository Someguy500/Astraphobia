using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    public GameObject lightningPrefab;
    public List<GameObject> activeBolts;
    public List<GameObject> inactiveBolts;

    public float alpha { get; set; }
    public float fadeSpeed { get; set; }
    public Color tint { get; set; }

    public Vector2 start { get { return activeBolts[0].GetComponent<Lightning>().start; } }
    public Vector2 end { get { return activeBolts[^1].GetComponent<Lightning>().end; } }
    
    public bool isComplete { get { return alpha <= 0; } }

    public void Initialize(int maxSegments)
    {
        activeBolts = new List<GameObject>();
        inactiveBolts = new List<GameObject>();

        for (int i = 0; i < maxSegments; i++)
        {
            GameObject segment = (GameObject) Instantiate(lightningPrefab, transform, true);
            segment.SetActive(false);
            inactiveBolts.Add(segment);
        }
    }

    public void ActivateBolt(Vector2 start, Vector2 end, Color c, float thickness)
    {
        tint = c;
        alpha = 1.5f;
        fadeSpeed = 0.03f;

        if (Vector2.Distance(end, start) <= 0)
        {
            Vector2 adjust = Random.insideUnitCircle;
        }
    }
    
}
