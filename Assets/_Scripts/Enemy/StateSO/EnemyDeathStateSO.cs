using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Death", menuName = "Enemy/States SO/Death State SO")]

public class EnemyDeathStateSO : StateNode
{
    EnemyControl owner;
    [SerializeField] float crystalSpawnChance;

    public override void Enter()
    {
        owner = user as EnemyControl;

        CollectiblesSpawner.Instance.SpawnCoin(owner.transform.position);

        if (Random.Range(0f,100f) <= crystalSpawnChance)
        {
            CollectiblesSpawner.Instance.SpawnCrystal(owner.transform.position);
        }

        owner.gameObject.SetActive(false);
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
