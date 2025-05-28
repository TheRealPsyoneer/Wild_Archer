using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour, IFactoryProduct
{
    const string PLAYER = "Player";
    const string RANGE_COIN = "RangeCoin";
    public bool isCollecting;

    public Stack<IFactoryProduct> pool { get; set; }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Initialize()
    {
        isCollecting = false;
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RANGE_COIN))
        {
            isCollecting = true;
        }

        if (other.CompareTag(PLAYER))
        {
            OnCollect();
            gameObject.SetActive(false);
        }
    }

    public abstract void OnCollect();

    public void OnDisable()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        pool.Push(this);
    }
}
