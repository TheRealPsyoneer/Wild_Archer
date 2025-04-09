using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class PlayerData
{
    public int currentLevel;
    public int currentWave;

    public void SaveData(PlayerData playerdata)
    {
        string json = JsonUtility.ToJson(playerdata);

        File.WriteAllText(Application.persistentDataPath + "/playerdata.json", json);
    }

    public PlayerData LoadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/playerdata.json");
        if (string.IsNullOrEmpty(json)) return null;

        PlayerData playerdata = new PlayerData();
        playerdata = JsonUtility.FromJson<PlayerData>(json);
        return playerdata;
    }
}
