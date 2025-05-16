using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    EnemyControl owner;
    bool isPlayerInRange;

    private void Awake()
    {
        owner = GetComponentInParent<EnemyControl>();

        isPlayerInRange = false;
    }

    private void Update()
    {
        if (owner.GetCurrentState() == State.Shot_Attack || owner.GetCurrentState() == State.GetHit) return;

        if (!isPlayerInRange) return;

        owner.ChangeStateTo(State.Shot_Attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void OnDisable()
    {
        isPlayerInRange = false;
    }

    public void DealDamageToPlayer()
    {
        if (isPlayerInRange)
        {
            PlayerControl.instance.TakeDamage(owner.CurrentDamage);
        }
    }
}
