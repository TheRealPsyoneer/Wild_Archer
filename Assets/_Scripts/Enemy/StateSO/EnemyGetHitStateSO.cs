using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Get Hit", menuName = "Enemy/States SO/Get Hit State SO")]
public class EnemyGetHitStateSO : StateNode
{
    EnemyControl owner;

    float initTime;
    float duration;

    bool isDead;

    public override void Enter()
    {
        owner = user as EnemyControl;

        owner.animator.SetTrigger("GetHit");
        owner.animator.Update(0);

        initTime = Time.time;
        duration = owner.animator.GetNextAnimatorStateInfo(0).length;

        isDead = owner.CurrentHealth <= 0 ? true : false;
    }

    public override void Execute()
    {
        if (Time.time - initTime >= duration)
        {
            if (isDead)
            {
                owner.ChangeStateTo(State.Death);
            }
            else
            {
                owner.ChangeStateTo(State.Move_Run);
            }
        }
    }

    public override void Exit()
    {
        
    }
}
