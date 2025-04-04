using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyControl : MonoBehaviour, IFactoryProduct
{
    public Stack<IFactoryProduct> pool { get; set; }

    public void Initialize()
    {
        gameObject.SetActive(true);
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
