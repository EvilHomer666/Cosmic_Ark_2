using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageCalc : MonoBehaviour
{
    private Text percentageText;

    // Awake is called before Update and the first frame update
    void Awake()
    {
        percentageText = GetComponent<Text>();
    }

    // Display value as percetage
    public void textUpdate(float value)
    {
        percentageText.text = $"Shields: {Mathf.RoundToInt(value * 10) + "%"}";
    }
}
