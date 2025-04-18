using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] FactorySO projectileFactory;
    public PlayerControl player { get; private set; }

    private void Awake()
    {
        player = GetComponent<PlayerControl>();
        projectileFactory.Initialize();
    }

    public void Shoot(EnemyControl enemy)
    {
        Arrow instance = projectileFactory.GetProduct(player.transform.position) as Arrow;
        instance.SetUpArrow(enemy);
    }
}
