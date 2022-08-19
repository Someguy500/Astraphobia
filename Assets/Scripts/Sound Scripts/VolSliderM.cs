using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VolSliderM : MonoBehaviour
{
    
    [SerializeField] private UnityEngine.UI.Slider MSlider;
    void Awake()
    {
        MSlider.onValueChanged.AddListener((v) =>
        {
            SoundManager.Instance.ChangeMVol(v);
        });
        
    }
}
