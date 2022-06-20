using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //vignette
using UnityEngine.Rendering; //volume

public class VignetteScript : MonoBehaviour
{
    private Vignette vignette = null; // check if vignette exists.
    public Volume volume = null;
    public Light2D GlobalLight2D = null;

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

    public void Start()
    {
        volume.weight = 0.6f;
        GlobalLight2D.intensity = 1f;
    }

    public void vignetteLink() //GL2D to manipulate bg brightness
    {
        GlobalLight2D.intensity = 1.0f;
        StartCoroutine(Period());
        StartCoroutine(SecPeriod());
    }

    IEnumerator Period()
    {
        yield return new WaitForSeconds(0.5f);
        GlobalLight2D.intensity = 0.5f;
    }

    IEnumerator SecPeriod()
    {
        yield return new WaitForSeconds(0.2f);
        GlobalLight2D.intensity = 2.5f;
    }

    IEnumerator Delay()
    {
        vignetteLink();
        yield return new WaitForSeconds(0.4f);
        GlobalLight2D.intensity = 1.5f;
        StartCoroutine(Period());
        GlobalLight2D.intensity = 1f;

        if (StressManager.stressLvl >= 20)
        {
            volume.weight = 0.6f;

        }
        if (StressManager.stressLvl >= 40)
        {
            volume.weight = 0.7f;
        }
        else if (StressManager.stressLvl >= 60)
        {
            volume.weight = 0.8f;
        }
        if (StressManager.stressLvl >= 80)
        {
            volume.weight = 0.9f;
            GlobalLight2D.intensity = 0.2f;
        }
        if (StressManager.stressLvl >= 90)
        {
            GlobalLight2D.intensity = 0.1f;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && StressManager.stressLvl <= 100) 
        {
            StartCoroutine(Delay());

        }

 

        for (int i = 0; i < 3; i++) vignette.intensity.Override(Mathf.Clamp((StressManager.stressLvl / 100) * (Mathf.Sin(Time.time) + i), 0.0f, 1f)); //Constant Vignette Values Bouncing


        /*        if (volume.weight > 0) //clamping values back and forth 
                {
                    for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
                }*/


    }

}