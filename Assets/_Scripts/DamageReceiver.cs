using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageReceiver : MonoBehaviour
{
    Health unitHealth;

    public event Action UnitGotHit;

    private void Awake()
    {
        unitHealth = GetComponent<Health>();
    }

    public void TakeDamage(float value)
    {
        unitHealth.ChangeHealth(-value);
        UnitGotHit?.Invoke();
    }
}
