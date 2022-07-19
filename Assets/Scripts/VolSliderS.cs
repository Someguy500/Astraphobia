using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolSliderS : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider sSlider;
    void Awake()
    {
        sSlider.onValueChanged.AddListener((v) =>
        {
            SoundManager.Instance.ChangeSVol(v);
        });
    }
}
