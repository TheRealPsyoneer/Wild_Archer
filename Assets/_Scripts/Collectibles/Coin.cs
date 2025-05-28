using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectibles
{
    [SerializeField] float flySpeed;
    [SerializeField] int value;


    public override void OnCollect()
    {
        PlayerControl.instance.ChangeMoney(value);
        PlayerControl.instance.PlayCoinVFX();
    }

    private void Update()
    {
        if (isCollecting)
        {
            Vector3 direction = (PlayerControl.instance.transform.position + Vector3.up * 2 - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * flySpeed);
        }
    }
}
