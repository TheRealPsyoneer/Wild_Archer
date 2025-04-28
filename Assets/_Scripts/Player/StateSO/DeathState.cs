using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Death", menuName = "Player/States SO/Death SO")]
public class DeathState : StateNode
{
    PlayerControl player;

    public override void Enter()
    {
        player = user as PlayerControl;

        player.animator.SetTrigger("Death");
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        
    }
}
