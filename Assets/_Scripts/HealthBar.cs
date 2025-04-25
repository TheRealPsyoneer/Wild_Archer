using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health unitHealth;
    [SerializeField] protected Slider currentHealthSlider;

    protected virtual void Awake()
    {
        currentHealthSlider.maxValue = unitHealth.unit.unitStats.defaultHealth;
        currentHealthSlider.value = currentHealthSlider.maxValue;

        unitHealth.HealthChanged += UpdateHealthUI;
    }

    protected void UpdateHealthUI()
    {
        currentHealthSlider.value = unitHealth.CurrentHealth;
    }
}
