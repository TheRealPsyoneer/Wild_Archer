using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectibles
{
    [SerializeField] int value = 1;
    [SerializeField] float flySpeed = 8;

    public override void OnCollect()
    {
        PlayerControl.instance.ChangeCrystal(value);
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
