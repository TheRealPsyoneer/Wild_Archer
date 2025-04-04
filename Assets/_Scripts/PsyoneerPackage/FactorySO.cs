using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Factory", menuName = "Factory SO")]
public class FactorySO : ScriptableObject
{
    [SerializeField] GameObject prefab;

    Stack<IFactoryProduct> productsPool = new();
    [SerializeField] int poolCapacity;

    public void Initialize()
    {
        for (int i = 0; i < poolCapacity; i++)
        {
            MakeNewProduct();
        }
    }

    public IFactoryProduct GetProduct()
    {
        if (productsPool.Count == 0)
        {
            MakeNewProduct();
        }

        IFactoryProduct instance = productsPool.Pop();
        instance.Initialize();
        return instance;
    }

    void MakeNewProduct()
    {
        GameObject product = Instantiate(prefab);
        IFactoryProduct instance = product.GetComponent<IFactoryProduct>();

        instance.pool = productsPool;
        product.SetActive(false);
    }
}
