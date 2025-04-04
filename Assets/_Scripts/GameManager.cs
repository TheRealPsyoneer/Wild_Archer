using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<GameObject> levelPrefabs;

    public PlayerData playerData { get; private set; }

    

    private void Awake()
    {
        Instance = this;

        LoadPlayerData();
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
    
    //
}
