using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    float health = 3;

    public void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
