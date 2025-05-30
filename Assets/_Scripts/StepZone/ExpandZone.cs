using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExpandZone : StepZone
{
    const string PLAYER = "Player";

    [SerializeField] int cost;
    [SerializeField] float delayBuy;
    [SerializeField] List<GameObject> walls;
    [SerializeField] PlatformPieceBuild nextZone;
    [SerializeField] GameObject buyZone;

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

        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }
        buyZone.SetActive(false);

        nextZone.StartBuilding();
    }

    public override void OnSteppedOff()
    {
        if (buyingCoroutine != null)
        {
            StopCoroutine(buyingCoroutine);
        }
    }
}
