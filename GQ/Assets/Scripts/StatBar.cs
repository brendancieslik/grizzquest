using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    private Slider slider;

    private float currentSliderVal;


    public float MaxValue = 100;

    private float currentStatValue = 80;

    
    public float MyCurrentStatValue
    {
        get
        {
            return currentStatValue;
        }
        set
        {
            if (value > MaxValue)
            {
                currentStatValue = MaxValue;
            }
            else if (value < 0)
            {
                currentStatValue = 0;
            }
            else
            {
                currentStatValue = value;
            }
            currentSliderVal = currentStatValue / MaxValue;
        }
    }

    public void Start()
    {
        slider = GetComponent<Slider>();


    }
    void Update()
    {
        slider.value = currentSliderVal;
    }
}
