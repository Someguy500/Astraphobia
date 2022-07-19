using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to Generate Shockingly Good 2D Lightning Effects in Unity (C#) by Aaron Davis
//URL : https://gamedevelopment.tutsplus.com/tutorials/how-to-generate-shockingly-good-2d-lightning-effects-in-unity-c--cms-21275

public class LightningManager : MonoBehaviour
{
    public GameObject boltPrefab;
    public float lightningDelay = 2f;

    private CameraZoomOutTest zoomCam;
    private StressManager stressManager;
    private VignetteScript postPros;

    private List<GameObject> activeBolts;
    private List<GameObject> inactiveBolts;
    private int maxBolts = 25;

    private Vector2 pos1, pos2;
    private float cd;
    private static readonly int IsStruck = Animator.StringToHash("isStruck");

    private void Awake()
    {
        zoomCam = GameObject.Find("Player Camera").GetComponent<CameraZoomOutTest>();
        stressManager = GameObject.Find("Volume Camera").GetComponent<StressManager>();
        postPros = GameObject.Find("Volume Camera").GetComponent<VignetteScript>();
    }

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
        
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        cd += Time.deltaTime;
        pos1 = transform.GetChild(1).position;
        pos2 = new Vector2(temp.x, temp.y);

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

        if(Input.GetKey(KeyCode.Mouse0) && zoomCam.isFullZoom && cd >= lightningDelay)
        { 
            RaycastHit2D hit = Physics2D.Raycast(pos1,pos2 - pos1, Vector2.Distance(pos1,pos2));
            
            Debug.DrawRay(pos1,pos2 - pos1, Color.cyan,5f);
            if (hit)
            { 
                if (hit.collider.CompareTag("LightningInteractables"))
                {
                    StartCoroutine(PlayAnimation(hit.collider.gameObject));
                }
            }
            cd = 0;
            CreateLightning();
        }
         
        for(int i = 0; i < activeBolts.Count; i++)
        {
            activeBolts[i].GetComponent<LightningBolt>().UpdateBolt();
            activeBolts[i].GetComponent<LightningBolt>().Draw();
        }
    }

    void CreateLightning()
    {
        stressManager.LightningStrike();
        postPros.LightningStrike();
        CreatePooledBolt(pos1,pos2, Color.white, 1f);
        SoundManager.Instance.PlaySoundSolo("Lightning");
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

    IEnumerator PlayAnimation(GameObject gameObject)
    {
        Animator anim = gameObject.GetComponent<Animator>();
        if (anim.GetBool(IsStruck) == false)
        {
            anim.SetBool(IsStruck, true);
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<PolygonCollider2D>().TryUpdateShapeToAttachedSprite();
        }
        yield return null;
    }
}
