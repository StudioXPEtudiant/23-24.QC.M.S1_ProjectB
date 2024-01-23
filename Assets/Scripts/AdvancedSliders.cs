using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedSliders : MonoBehaviour
{
    public Slider slider;
    public TMP_Text textValue;

    private void Start()
    {
        textValue.text = slider.value.ToString();
        
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        textValue.text = value.ToString();
    }
}
