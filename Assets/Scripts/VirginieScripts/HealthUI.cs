using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float courage)
    {
        slider.maxValue = courage;
    }

    public void SetHealth(float courage)
    {
        slider.value = courage;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
