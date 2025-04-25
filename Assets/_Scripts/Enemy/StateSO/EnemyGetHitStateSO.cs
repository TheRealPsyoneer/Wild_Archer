using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Get Hit", menuName = "Enemy/States SO/Get Hit State SO")]
public class EnemyGetHitStateSO : StateNode
{
    EnemyControl owner;

    [SerializeField] AnimationClip getHitClip;

    float initTime;
    float duration;

    public override void Enter()
    {
        owner = user as EnemyControl;

        owner.animator.SetTrigger("GetHit");

        initTime = Time.time;
        duration = getHitClip.length * 0.4f;
    }

    public override void Execute()
    {
        if (Time.time - initTime >= duration)
        {
            if (owner.CurrentHealth <= 0)
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
