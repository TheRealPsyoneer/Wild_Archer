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

        Debug.Log(PlayerControl.instance == null);
        owner.nav.SetDestination(PlayerControl.instance.transform.position);
    }

    public override void Execute()
    {
        Vector3 lookTarget = new Vector3(PlayerControl.instance.transform.position.x, 0, PlayerControl.instance.transform.position.z);

        owner.model.LookAt(lookTarget);

        //Vector3 direction = (lookTarget - owner.transform.position).normalized;

        //owner.transform.Translate((direction) * Time.deltaTime * owner.CurrentSpeed);

        
    }

    public override void Exit()
    {
        
    }
}
