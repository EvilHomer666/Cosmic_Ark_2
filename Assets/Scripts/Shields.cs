using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shields : MonoBehaviour
{
    [SerializeField] Slider slider;

    // Singleton used to carry score across scenes
    public static Shields Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
