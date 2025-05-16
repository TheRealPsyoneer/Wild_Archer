using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    UnitControl unit;

    private void Awake()
    {
        unit = GetComponentInParent<UnitControl>();
    }

    public void DealDamage(float value, DamageReceiver target)
    {
        target.TakeDamage(value);
    }
}
