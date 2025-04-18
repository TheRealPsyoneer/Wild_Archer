using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class EnemyControl : MonoBehaviour, IFactoryProduct
{
    public Stack<IFactoryProduct> pool { get; set; }
    Rigidbody rb;
    public event Action<EnemyControl> BeingKilledEvent;

    public void Initialize()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        rb.DOMove(PlayerControl.instance.transform.position, 5f);
    }

    private void OnDisable()
    {
        BeingKilledEvent?.Invoke(this);
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
