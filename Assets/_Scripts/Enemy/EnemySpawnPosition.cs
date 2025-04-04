using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    public static List<EnemySpawnPosition> positions = new();

    private void Awake()
    {
        positions.Add(this);
    }

    private void OnDestroy()
    {
        positions.Clear();
    }
}
