using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpiritStressLink : MonoBehaviour
{
    public Light2D spiritLight;
    public static bool additiveStress = false;

    void stressGauge()
    {
        if (StressManager.stressLvl > 13) //cast 16 times
        {
            spiritLight.pointLightOuterRadius = 0;
        }
    }

    void radiusStress() //stressRadius needs to restore visual radius
    {
        if (StressManager.stressLvl >= 0 && StressManager.stressLvl < 5)
            {
                spiritLight.pointLightOuterRadius = 3.4f;
            }
        else if (StressManager.stressLvl >= 5 && StressManager.stressLvl < 10)
            {
            /*spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 2.9f, 3.4f);*/
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - (additiveStress ? -0.01f : 0.01f), 2.9f, 2.9f);
        }
        else if (StressManager.stressLvl >= 10 && StressManager.stressLvl < 16)
            {
            /*spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - 0.01f, 1.9f, 3.4f);*/
            spiritLight.pointLightOuterRadius = Mathf.Clamp(spiritLight.pointLightOuterRadius - (additiveStress ? -0.01f : 0.01f), 1.9f, 2.9f);
        }

        additiveStress = false;
        Debug.Log(spiritLight.pointLightOuterRadius);
    }

    public void LightningStrikeStress()
    {
        if (StressManager.stressLvl < 16)
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
        additiveStress = false;
    }

    private void Update()
    {
        /*spiritLight.pointLightOuterRadius -= 0.01f;*/
        LightningStrikeStress();
        
    }


}
