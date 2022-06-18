using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //volume
using UnityEngine.Rendering.Universal; //vignette

public class VignetteScript : MonoBehaviour
{

    /*public float volWeight = 0.25f;*/
    /*public float intensity = 0.25f;*/

    public Volume volume = null;
    private Vignette vignette = null; // check if vignette exists.

    float value = 0.0f;
    float volVal = 0;



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
        vignette.intensity.Override(Mathf.Clamp((1/StressManager.stressLvl) * 10f, 0.0f, 1f));
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        vignetteLink();

    }


    private void Update()
    {


        if (Input.GetKey(KeyCode.Mouse1) && StressManager.stressLvl > 1)
        {
            vignetteLink();
        }


        /*        if (volume.weight > 0) //clamping values back and forth 
                {
                    for (int i = 0; i < 3; i++) volume.weight = (Mathf.Clamp(0.4f * (Mathf.Sin(Time.time) + i), 0.0f, 0.9f));
                }*/

        if (Input.GetKeyDown("1"))
        {
            value = 0.25f; //ori val
            vignette.intensity.Override(value); // changing vignette's intensity changing value.
            Debug.Log(value);
        }
        else if (Input.GetKeyDown("2"))
        {
            volVal = 0;
            volume.weight = volVal; // changing volume's weight
            Debug.Log(volVal);
        }
        else if (Input.GetKeyDown("3"))
        {
            volVal = 1;
            volume.weight = volVal;
            Debug.Log(volVal);
        }

    }

}