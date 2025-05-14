using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        MakeOwnerFaceTarget();

        initTime = Time.time;

        owner.animator.SetTrigger("Hit");
        owner.animator.Update(0);

        duration = owner.animator.GetNextAnimatorStateInfo(0).length;
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

    private void MakeOwnerFaceTarget()
    {
        Vector2 ownerNormalizedPosition = new Vector2(owner.transform.position.x, owner.transform.position.z);
        Vector2 playerNormalizedPosition = new Vector2(PlayerControl.instance.transform.position.x, PlayerControl.instance.transform.position.z);

        Vector2 lookDirection = playerNormalizedPosition - ownerNormalizedPosition;

        float turningAngle = Vector2.SignedAngle(lookDirection, Vector2.up);

        owner.transform.DORotate(new Vector3(0, turningAngle, 0), 0.2f);

        //owner.transform.rotation = Quaternion.Euler(new Vector3(0, turningAngle, 0));
    }
}
