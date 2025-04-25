using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Death", menuName = "Enemy/States SO/Death State SO")]

public class EnemyDeathStateSO : StateNode
{
    EnemyControl owner;

    public override void Enter()
    {
        owner = user as EnemyControl;

        owner.gameObject.SetActive(false);
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
