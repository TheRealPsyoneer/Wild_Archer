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
        player.characterController.Move(new Vector3(player.direction.x, -1, player.direction.y) * Time.deltaTime * player.speed);

        float angle = Vector2.SignedAngle(Vector3.up, player.direction);
        player.skin.localRotation = Quaternion.Euler(0, -angle, 0);

        if (player.speed < 0.1f)
        {
            player.ChangeStateTo(State.Idle);
        }
    }

    public override void Exit()
    {
        
    }
}
