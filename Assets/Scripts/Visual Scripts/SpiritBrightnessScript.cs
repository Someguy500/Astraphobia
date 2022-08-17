using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //volume
using UnityEngine.Rendering.Universal;

public class SpiritBrightnessScript : MonoBehaviour
{
    public Volume volume = null;
    public Light2D GlobalLight2D = null;
    public Light2D spiritLight = null;


    public void Start()
    {
        GlobalLight2D.intensity = 1f;
    }

    public void gLight2DModifier() //GL2D to manipulate bg brightness
    {
        StartCoroutine(Period());
        StartCoroutine(SecPeriod());
        GlobalLight2D.enabled = false;
    }

    IEnumerator Period()
    {
        GlobalLight2D.enabled = true;
        yield return new WaitForSeconds(0.25f);
        GlobalLight2D.intensity = 0.5f;

        if (StressManager.stressLvl >= 100)
        {
            GlobalLight2D.intensity = 0;
        }
    }

    IEnumerator SecPeriod()
    {
        yield return new WaitForSeconds(0.4f);
        GlobalLight2D.intensity = 2.5f;
    }

    IEnumerator Delay()
    {
        gLight2DModifier();
        yield return new WaitForSeconds(0.4f);
        GlobalLight2D.intensity = 1.5f;
        StartCoroutine(Period());
        GlobalLight2D.intensity = 1f;

        if (StressManager.stressLvl >= 20f)
        {
            spiritLight.pointLightOuterRadius = 0f;
        }
        else if (StressManager.stressLvl >= 40f)
        {
            spiritLight.pointLightOuterRadius = 2.1f;
        }
        else if (StressManager.stressLvl >= 60f)
        {
            spiritLight.pointLightOuterRadius = 2.8f;
        }
        else if (StressManager.stressLvl >= 70)
        {
            spiritLight.pointLightOuterRadius = 1.4f;
        }
        else if (StressManager.stressLvl >= 80)
        {
            spiritLight.pointLightOuterRadius = 0.7f;
        }
    }

    public void LightningStrike()
    {
        if (StressManager.stressLvl <= 100)
            StartCoroutine(Delay());
    }

}
