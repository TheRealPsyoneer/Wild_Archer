using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Run", menuName = "Enemy/States SO/Run State SO")]
public class EnemyRunningStateSO : StateNode
{
    EnemyControl owner;

    public override void Enter()
    {
        owner = user as EnemyControl;
    }

    public override void Execute()
    {
        //Vector3 lookTarget = new Vector3(PlayerControl.instance.transform.position.x, 0, PlayerControl.instance.transform.position.z);

        //Vector3 direction = (lookTarget - owner.transform.position).normalized;

        //owner.nav.SetDestination((direction) * Time.deltaTime * owner.CurrentSpeed);

        owner.nav.SetDestination(PlayerControl.instance.transform.position);
    }

    public override void Exit()
    {
        if (owner.nav.hasPath)
        {
            owner.nav.ResetPath();
        }
    }
}
