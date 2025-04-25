using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "Attack", menuName = "Enemy/States SO/Attack State SO")]
public class EnemyAttackStateSO : StateNode
{
    EnemyControl owner;
    [SerializeField] AnimationClip attackClip;

    float initTime;
    float duration;


    public override void Enter()
    {
        owner = user as EnemyControl;

        Vector3 lookDirection = new Vector3(PlayerControl.instance.transform.position.x, 0, PlayerControl.instance.transform.position.z);

        owner.model.LookAt(lookDirection);

        initTime = Time.time;
        duration = attackClip.length;
        owner.animator.SetTrigger("Hit");
    }

    public override void Execute()
    {
        if (Time.time - initTime >= duration)
        {
            owner.ChangeStateTo(State.Move_Run);
        }
    }

    public override void Exit()
    {
        
    }
}
