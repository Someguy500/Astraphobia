using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VolSliderM : MonoBehaviour
{
    
    [SerializeField] private UnityEngine.UI.Slider MSlider;
    void Start()
    {
        MSlider.onValueChanged.AddListener((v) =>
        {
            Debug.Log(v.ToString("0.00"));
        });
    }

    void Update()
    {
        
    }
}
