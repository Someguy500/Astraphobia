using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //volume
using UnityEngine.Rendering.Universal; //vignette

public class VignetteScript : MonoBehaviour
{
    /*public ClampedFloatParameter intensity; // A Volume Parameter that holds float val between a min and max value.*/

    public float intensity = 0.75f;
    public float duration = 0.5f;

    public Volume volume = null;
    private Vignette vignette = null; // check if vignette exists.

    float value = 0;
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

 /*   public void FadeIn()
    {
        StartCoroutine(Fade(0, intensity));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, intensity));
    }

    private IEnumerator Fade(float startValue, float endValue)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime <= duration)
        {
            float blend = elapsedTime / duration;
            elapsedTime += Time.deltaTime;

            float intensity = Mathf.Lerp(startValue, endValue, blend);
            ApplyValue(intensity);

            yield return null;
        }



    }

    private void ApplyValue(float value)
    {
        vignette.intensity.Override(value);
    }*/

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            value = 0;
            vignette.intensity.Override(value); // changing vignette's intensity changing value.
            Debug.Log(value);
        }
        else if (Input.GetKeyDown("2"))
        {
            value = 0.25f; //ori val
            vignette.intensity.Override(value);
        }
        else if (Input.GetKeyDown("3"))
        {
            value = 1;
            vignette.intensity.Override(value);
        }
        else if (Input.GetKeyDown("4"))
        {
            volVal = 0;
            volume.weight = volVal; // changing volume's weight
            Debug.Log(volVal);
        }
        else if (Input.GetKeyDown("5"))
        {
            volVal = 1;
            volume.weight = volVal; // changing volume's weight
            Debug.Log(volVal);
        }

    }

}
