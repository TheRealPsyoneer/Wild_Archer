using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static WaveInfoSO;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<FactorySO> enemyFactories;

    public List<Area> areaLevels;
    [Serializable]
    public struct Area
    {
        public List<WaveInfoSO> waves;
    }

    PlayerData data => GameManager.Instance.playerData;

    private void Awake()
    {
        InitializeEnemyFactory();
    }

    private void InitializeEnemyFactory()
    {
        foreach (FactorySO factory in enemyFactories)
        {
            factory.Initialize();
        }
    }

    // For Testing
    public void StartTheWave()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        int spawnPositionIndex = UnityEngine.Random.Range(0, EnemySpawnPosition.positions.Count);
        Vector3 spawnPosition = EnemySpawnPosition.positions[spawnPositionIndex].transform.position;
        WaveInfoSO waveInstance = areaLevels[data.currentLevel - 1].waves[data.currentWave - 1];

        foreach (EnemyInfo enemies in waveInstance.enemyList)
        {
            for (int i = 0; i < enemies.quantity; i++)
            {
                EnemyControl instance = enemies.enemyFactory.GetProduct() as EnemyControl;
                instance.GetGameObject().transform.position = spawnPosition + Vector3.up;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    //
}
