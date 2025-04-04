using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Wave", menuName = "Enemy/Wave SO")]
public class WaveInfoSO : ScriptableObject
{
    public List<EnemyInfo> enemyList;

    [Serializable]
    public struct EnemyInfo
    {
        public FactorySO enemyFactory;
        public int quantity;
    }

    //public void StartSpawningEnemy(Vector3 spawnPosition)
    //{
    //    foreach (EnemyInfo enemies in enemyList)
    //    {
    //        for (int i=0; i<enemies.quantity; i++)
    //        {
    //            EnemyControl instance = enemies.enemyFactory.GetProduct() as EnemyControl;
    //            instance.GetGameObject().transform.position = spawnPosition;
    //        }
    //    }
    //}
}
