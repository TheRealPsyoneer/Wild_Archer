using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shot", menuName = "Player/States SO/Shot SO")]
public class ShotState : StateNode
{
    PlayerControl player;
    [SerializeField] AnimationClip shotAnimation;
    float duration;
    float initTime;

    public override void Enter()
    {
        player = user as PlayerControl;
        player.isShooting = true;
        duration = shotAnimation.length;

        player.animator.SetLayerWeight(player.animator.GetLayerIndex("Up"), 0.5f);
        player.animator.SetBool("Shooting", true);
        player.animator.SetTrigger("Shot");
        initTime = Time.time;

        player.shooter.Shoot(player.currentTarget);
    }

    public override void Execute()
    {
        if (Time.time - initTime > duration)
        {
            player.ChangeStateTo(State.Idle);
        }

        if (player.currentTarget != null)
        {
            Vector3 lookDirection = (player.currentTarget.transform.position - player.transform.position).normalized;
            float angle = Vector2.SignedAngle(Vector2.up, new Vector2(lookDirection.x, lookDirection.z));
            player.skin.localRotation = Quaternion.Euler(0, -angle, 0);
        }

        //player.animator.SetFloat("X", player.direction.x);
        //player.animator.SetFloat("Z", player.direction.y);
        player.navMeshAgent.Move(new Vector3(player.direction.x, -1, player.direction.y) * Time.deltaTime * player.speed);
        
        
    }

    public override void Exit()
    {
        player.animator.SetLayerWeight(player.animator.GetLayerIndex("Up"), 0);
        player.animator.SetBool("Shooting", false);
        player.SetTarget(null);
        player.isShooting = false;

    }
}
