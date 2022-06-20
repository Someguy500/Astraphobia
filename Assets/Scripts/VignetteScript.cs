using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //volume
using UnityEngine.Rendering.Universal; //vignette

public class VignetteScript : MonoBehaviour
{

    public Volume volume = null;
    private Vignette vignette = null; // check if vignette exists.

    private void Awake()
    {
        if (volume.profile.TryGet(out Vignette vignette)) //Testing to see if vignette exists.
        {
            this.vignette = vignette;
            Debug.Log("vignette");
        }
        else
        {
            Debug.Log("Does not exist");
        }

    }

    public void vignetteLink()
    {


        for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.6f, 0.7f));
        volume.weight = 0.6f;
        StartCoroutine(Period());

    }

    IEnumerator Period()
    {
        yield return new WaitForSeconds(0.3f);
        volume.weight = 1f;
    }

    IEnumerator Delay()
    {
        vignetteLink();
        yield return new WaitForSeconds(0.4f);
        volume.weight = 0;
        StartCoroutine(Period());
        volume.weight = 0.8f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && StressManager.stressLvl <= 100)
        {
            StartCoroutine(Delay());
        }

        for (int i = 0; i < 3; i++) vignette.intensity.Override(Mathf.Clamp((StressManager.stressLvl/100) * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));

        /*        if (volume.weight > 0) //clamping values back and forth 
                {
                    for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
                }*/


    }

}