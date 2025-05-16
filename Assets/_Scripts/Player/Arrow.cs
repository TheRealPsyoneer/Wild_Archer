using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Arrow : UnitControl, IFactoryProduct
{
    public float CurrentDamage { get; private set; }
    public float CurrentSpeed { get; private set; }
    public Stack<IFactoryProduct> pool { get; set; }
    public EnemyControl enemy { get; set; }

    public event Action<float, DamageReceiver> TargetHitEvent;

    private void Awake()
    {
        CurrentSpeed = unitStats.defaultSpeed;

        TargetHitEvent += GetComponent<DamageDealer>().DealDamage;
    }

    public void Initialize()
    {
        CurrentDamage = PlayerControl.instance.CurrentDamage;
        gameObject.SetActive(true);
    }

    public void SetUpArrow(EnemyControl target)
    {
        enemy = target;
    }

    private void Update()
    {
        FlyToTarget();
    }

    private void FlyToTarget()
    {
        if (enemy == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;

        transform.LookAt(enemy.transform.position + enemy.shootHitOffset);

        transform.Translate(Vector3.forward * Time.deltaTime * CurrentSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy.gameObject)
        {
            DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
            TargetHitEvent?.Invoke(CurrentDamage, damageReceiver);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        pool.Push(this);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
