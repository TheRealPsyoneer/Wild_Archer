using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health unitHealth;
    [SerializeField] Slider currentHealthSlider;

    private void Awake()
    {
        currentHealthSlider.maxValue = unitHealth.unit.unitStats.defaultHealth;
        currentHealthSlider.value = currentHealthSlider.maxValue;

        unitHealth.HealthChanged += UpdateHealthUI;
    }

    void UpdateHealthUI()
    {
        currentHealthSlider.value = unitHealth.CurrentHealth;
    }
}
