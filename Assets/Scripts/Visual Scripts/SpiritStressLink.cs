using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpiritStressLink : MonoBehaviour
{
    public Light2D spiritLight;

    void stressGauge()
    {
        if (StressManager.stressLvl >= 100)
        {
            spiritLight.pointLightOuterRadius = 0;
        }
    }

    void radiusStress()
    {
        if (StressManager.stressLvl < 20f)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 3.0f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 3.0f;*/
        }
        else if (StressManager.stressLvl < 40f)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 2.5f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 2.5f;*/
        }
        else if (StressManager.stressLvl < 60f)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 2.0f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 2.0f;*/
        }
        else if (StressManager.stressLvl < 70)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 1.5f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 1.5f;*/
        }
        else if (StressManager.stressLvl < 80)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 1.0f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 1.0f;*/
        }


    }

    public void LightningStrikeStress()
    {
        if (StressManager.stressLvl <= 100)
        {
            stressGauge();
            radiusStress();
        }
            
    }

    public void LightningLight()
    {
        StartCoroutine(lightChange());
    }
    
    IEnumerator lightChange()
    {
        spiritLight.lightType = Light2D.LightType.Global;
        yield return new WaitForSeconds(0.5f);
        spiritLight.lightType = Light2D.LightType.Point;
        Debug.Log("LIGHT");
    }

    private void Update()
    {
        /*spiritLight.pointLightOuterRadius -= 0.01f;*/
        LightningStrikeStress();
        
    }


}
