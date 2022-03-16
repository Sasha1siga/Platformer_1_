using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    public void SetHealth(int health)
    {
        healthBarSlider.value = health;
        fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);// 0-1 function Value
    }
    public void SetMaxHealth(int health)
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
}
