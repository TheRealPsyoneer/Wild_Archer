using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveInfoSO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<GameObject> levelPrefabs;
    [SerializeField] List<FactorySO> enemyFactories;

    PlayerData playerData;

    public List<Area> areaLevels;
    [Serializable]
    public struct Area
    {
        public List<WaveInfoSO> waves;
    }

    private void Awake()
    {
        Instance = this;

        LoadPlayerData();
        InitializeEnemyFactory();
    }

    private void InitializeEnemyFactory()
    {
        foreach (FactorySO factory in enemyFactories)
        {
            factory.Initialize();
        }
    }

    private void LoadPlayerData()
    {
        // Change later
        playerData = new();
        playerData.currentLevel = 1;
        playerData.currentWave = 1;
        //
    }

    private void Start()
    {
        Instantiate(levelPrefabs[playerData.currentLevel - 1]);
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
        WaveInfoSO waveInstance = areaLevels[playerData.currentLevel - 1].waves[playerData.currentWave-1];

        foreach (EnemyInfo enemies in waveInstance.enemyList)
        {
            for (int i = 0; i < enemies.quantity; i++)
            {
                EnemyControl instance = enemies.enemyFactory.GetProduct() as EnemyControl;
                instance.GetGameObject().transform.position = spawnPosition;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    //
}
