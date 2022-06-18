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
        
        if(StressManager.stressLvl >= 0 && StressManager.stressLvl <= 50)
        {
            for (int i = 0; i < 3; i++) vignette.intensity.Override(Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
            for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.5f, 0.9f));
        }
        else if(StressManager.stressLvl > 50 && StressManager.stressLvl <= 100)
        {
            for (int i = 0; i < 3; i++) vignette.intensity.Override(Mathf.Clamp(0.6f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
            volume.weight = 1f;
        }
        


    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        vignetteLink();

    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.Mouse1) && StressManager.stressLvl <= 100)
        {
            StartCoroutine(Delay());
      
        }


/*        if (volume.weight > 0) //clamping values back and forth 
        {
            for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
        }*/


    }

}