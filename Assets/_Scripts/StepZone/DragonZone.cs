using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragonZone : StepZone
{
    [SerializeField] GameObject dragon;
    [SerializeField] Vector3 spawnDragonPosition;
    [SerializeField] float delayBuy;
    [SerializeField] int cost;
    [SerializeField] float flyTime;

    Coroutine buyingCoroutine;

    public override void OnSteppedOn()
    {
        //Debug.Log("In");
        if (PlayerControl.instance.currentMoney >= cost)
        {
            buyingCoroutine = StartCoroutine(BuyCoroutine());
        }
    }

    IEnumerator BuyCoroutine()
    {
        yield return new WaitForSeconds(delayBuy);
        PlayerControl.instance.ChangeMoney(-cost);

        dragon.transform.DOMove(PlayerControl.instance.transform.position + spawnDragonPosition, flyTime);
    }

    public override void OnSteppedOff()
    {
        if (buyingCoroutine != null)
        {
            StopCoroutine(buyingCoroutine);
        }
    }

}
