using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shields : MonoBehaviour
{
    public Slider slider;

    // Methods to show shield power through the slider component
    public void SetMaxShield(float shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }

    public void SetShield(float shield)
    {
        slider.value = shield;
    }
}
