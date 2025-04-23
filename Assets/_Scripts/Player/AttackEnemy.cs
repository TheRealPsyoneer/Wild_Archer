using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    HashSet<EnemyControl> enemies = new();

    private void Update()
    {
        if (enemies.Count == 0 || player.GetCurrentState() == State.Shot_Attack) return;

        StartAttack();
    }

    private void StartAttack()
    {
        float distance = float.MaxValue;
        EnemyControl target = null;
        foreach (EnemyControl enemy in enemies)
        {
            float curDistance = (enemy.transform.position - transform.position).magnitude;
            if (distance > curDistance)
            {
                distance = curDistance;
                target = enemy;
            }
        }
        player.SetTarget(target);
    }

    void OnEnemyKilled(EnemyControl enemy)
    {
        enemies.Remove(enemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyControl enemy = other.GetComponent<EnemyControl>();

        if (enemy != null && !enemies.Contains(enemy))
        {
            enemies.Add(enemy);
            enemy.BeingKilledEvent += OnEnemyKilled;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyControl enemy = other.GetComponent<EnemyControl>();

        if (enemy != null && enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }
}
