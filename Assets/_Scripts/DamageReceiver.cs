using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    Health unitHealth;

    private void Awake()
    {
        unitHealth = GetComponent<Health>();
    }

    public void TakeDamage(float value)
    {
        unitHealth.ChangeHealth(-value);
    }
}
