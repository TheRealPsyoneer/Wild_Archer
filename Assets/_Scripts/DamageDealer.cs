using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public void DealDamage(float value, DamageReceiver target)
    {
        target.TakeDamage(value);
    }
}
