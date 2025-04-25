using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public UnitControl unit { get; private set; }

    float currentHealth;

    public event Action HealthChanged;

    public float CurrentHealth
    { 
        get =>  currentHealth;
        private set
        {
            if (value > unit.unitStats.defaultHealth) value = unit.unitStats.defaultHealth;

            currentHealth = value;

            HealthChanged?.Invoke();

            //if (currentHealth < 0.1f) UnitDie();
        }
    }    

    private void Awake()
    {
        unit = GetComponent<UnitControl>();

        CurrentHealth = unit.unitStats.defaultHealth;
    }

    public void ChangeHealth(float amount)
    {
        CurrentHealth += amount;
    }

    void UnitDie()
    {
        gameObject.SetActive(false);
    }
}
