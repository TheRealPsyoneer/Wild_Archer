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
        Debug.Log("Enter Shot");
        player = user as PlayerControl;
        duration = shotAnimation.length;

        player.animator.SetLayerWeight(player.animator.GetLayerIndex("Up"), 0.5f);
        player.animator.SetBool("Shooting", true);
        player.animator.SetTrigger("Shot");
        initTime = Time.time;
    }

    public override void Execute()
    {
        if (Time.time - initTime > duration)
        {
            player.ChangeStateTo(State.Idle);
        }

        player.SetDirection((player.currentTarget.transform.position - player.transform.position).normalized);

        player.animator.SetFloat("X", player.direction.x);
        player.animator.SetFloat("Z", player.direction.y);
        player.characterController.Move(new Vector3(player.direction.x, -1, player.direction.y) * Time.deltaTime * player.speed);
        Debug.Log(player.speed);
        
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(player.direction.x, player.direction.y));
        player.skin.localRotation = Quaternion.Euler(0, -angle, 0);
    }

    public override void Exit()
    {
        player.animator.SetLayerWeight(player.animator.GetLayerIndex("Up"), 0);
        player.animator.SetBool("Shooting", false);
        player.SetTarget(null);
    }
}
