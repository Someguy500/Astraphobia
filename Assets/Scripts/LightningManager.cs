using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to Generate Shockingly Good 2D Lightning Effects in Unity (C#) by Aaron Davis
//URL : https://gamedevelopment.tutsplus.com/tutorials/how-to-generate-shockingly-good-2d-lightning-effects-in-unity-c--cms-21275

public class LightningManager : MonoBehaviour
{
    public GameObject boltPrefab;

    private List<GameObject> activeBolts;
    private List<GameObject> inactiveBolts;
    private int maxBolts = 25;

    private int clicks = 0;
    private Vector2 pos1, pos2;

    private void Start()
    {
        activeBolts = new List<GameObject>();
        inactiveBolts = new List<GameObject>();

        GameObject p = this.gameObject;

        for (int i = 0; i < maxBolts; i++)
        {
            GameObject bolt = (GameObject)Instantiate(boltPrefab);

            bolt.transform.parent = p.transform.GetChild(0);
            bolt.GetComponent<LightningBolt>().Initialize(25);
            bolt.SetActive(false);
            inactiveBolts.Add(bolt);
        }
    }

    void Update()
    {
        GameObject boltObj;
        LightningBolt bolt;

        int activeCount = activeBolts.Count;

        for (int i = activeCount - 1; i >= 0; i--)
        {
            boltObj = activeBolts[i];
            bolt = boltObj.GetComponent<LightningBolt>();

            if (bolt.isComplete)
            {
                bolt.DeactivateSegment();
                boltObj.SetActive(false);
                activeBolts.RemoveAt(i);
                inactiveBolts.Add(boltObj);
            }
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            if(clicks == 0)
            {
                Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos1 = new Vector2(temp.x, temp.y);
            }
            else if(clicks == 1)
            {
                Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos2 = new Vector2(temp.x, temp.y);
                 
                CreatePooledBolt(pos1,pos2, Color.white, 1f);
            }
             
            clicks++;
             
            if(clicks > 1) clicks = 0;
        }
         
        for(int i = 0; i < activeBolts.Count; i++)
        {
            activeBolts[i].GetComponent<LightningBolt>().UpdateBolt();
            activeBolts[i].GetComponent<LightningBolt>().Draw();
        }
    }

    void CreatePooledBolt(Vector2 source, Vector2 dest, Color color, float thickness)
    {
        if (inactiveBolts.Count > 0)
        {
            GameObject boltObj = inactiveBolts[inactiveBolts.Count - 1];

            boltObj.SetActive(true);

            activeBolts.Add(boltObj);
            inactiveBolts.RemoveAt(inactiveBolts.Count - 1);

            LightningBolt boltComponent = boltObj.GetComponent<LightningBolt>();
            boltComponent.ActivateBolt(source, dest, color, thickness);
        }
    }
}
