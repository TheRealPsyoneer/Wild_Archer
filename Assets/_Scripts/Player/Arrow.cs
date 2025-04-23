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

    bool isSetUp;

    private void Awake()
    {
        CurrentDamage = unitStats.defaultDamage;
        CurrentSpeed = unitStats.defaultSpeed;
        isSetUp = false;

        TargetHitEvent += GetComponent<DamageDealer>().DealDamage;
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }

    public void SetUpArrow(EnemyControl target)
    {
        enemy = target;
        enemy.BeingKilledEvent += Deactivate;

        isSetUp = true;
    }

    private void Update()
    {
        if (!isSetUp) return;
        FlyToTarget();
    }

    private void FlyToTarget()
    {
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

    void Deactivate(EnemyControl enemy)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        isSetUp = false;
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
