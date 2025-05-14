using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Player/States SO/Move SO")]
public class MoveState : StateNode
{
    PlayerControl player;

    public override void Enter()
    {
        player = user as PlayerControl;
    }

    public override void Execute()
    {
        player.animator.SetFloat("X", player.direction.x);
        player.animator.SetFloat("Z", player.direction.y);
        player.navMeshAgent.Move(new Vector3(player.direction.x, 0, player.direction.y) * Time.deltaTime * player.speed);

        float angle = Vector2.SignedAngle(Vector3.up, player.direction);

        player.skin.localRotation = Quaternion.Euler(0, -angle, 0);
        //player.skin.localRotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, -angle, 0), Time.deltaTime);


        if (player.currentTarget != null)
        {
            player.ChangeStateTo(State.Shot_Attack);
        }

        else if (player.speed < 0.1f)
        {
            player.ChangeStateTo(State.Idle);
        }
    }

    public override void Exit()
    {
        
    }
}
