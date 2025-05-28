using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawner : MonoBehaviour
{
    public static CollectiblesSpawner Instance;

    [SerializeField] FactorySO coinFactory;

    private void Awake()
    {
        Instance = this;

        coinFactory.Initialize();
    }

    public void SpawnCoin(Vector3 spawnPosition)
    {
        coinFactory.GetProduct(spawnPosition);
    }
}
