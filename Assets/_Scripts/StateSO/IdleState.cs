using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle", menuName = "Player/States SO/Idle SO")]
public class IdleState : StateNode
{
    PlayerControl player;
    public override void Enter()
    {
        player = user as PlayerControl;
    }

    public override void Execute()
    {
        if (player.speed > 0)
        {
            player.ChangeStateTo(State.Move);
        }
    }

    public override void Exit()
    {
        
    }
}
