using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fly To Player", menuName = "Dragon/States SO/Fly To Player State SO")]
public class DragonFlyToPlayerState : StateNode
{
    DragonController dragon;
    [SerializeField] float distanceToPlayer;

    public override void Enter()
    {
        dragon = user as DragonController;
    }

    public override void Execute()
    {
        Vector3 direction = (PlayerControl.instance.transform.position - dragon.transform.position);

        if (direction.magnitude >= distanceToPlayer)
        {
            Vector2 normalizedDirection = new Vector2(direction.normalized.x, direction.normalized.z);

            float angle = Vector2.SignedAngle(normalizedDirection, Vector2.up);
            dragon.transform.rotation = Quaternion.Euler(0, angle, 0);

            dragon.transform.Translate(direction.normalized * Time.deltaTime * dragon.unitStats.defaultSpeed);
        }
    }

    public override void Exit()
    {
        
    }
}
