using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpiritStressLink : MonoBehaviour
{
    public Light2D spiritLight;
    

    void stressGauge()
    {
        if (StressManager.stressLvl >= 16)
        {
            spiritLight.pointLightOuterRadius = 0;
        }
    }

    void radiusStress()
    {
        if (StressManager.stressLvl >= 0 && StressManager.stressLvl < 5)
        {
            spiritLight.pointLightOuterRadius = 3.5f;
        }
        else if (StressManager.stressLvl >= 5 && StressManager.stressLvl < 10)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 3.0f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 3.0f;*/
        }
        else if (StressManager.stressLvl >= 10 && StressManager.stressLvl <= 16)
        {
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 2.0f, 3.5f);
            /*spiritLight.pointLightOuterRadius = 2.5f;*/
        }


    }

    public void LightningStrikeStress()
    {
        if (StressManager.stressLvl <= 16)
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
