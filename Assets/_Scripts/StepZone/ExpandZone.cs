using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExpandZone : StepZone
{
    const string PLAYER = "Player";

    [SerializeField] int cost;
    [SerializeField] float delayBuy;
    [SerializeField] List<GameObject> walls;
    [SerializeField] GameObject nextZone;
    [SerializeField] GameObject buyZone;

    Coroutine buyingCoroutine;

    public override void OnSteppedOn()
    {
        if (PlayerControl.instance.currentMoney >= cost)
        {
            buyingCoroutine = StartCoroutine(StartBuying());
        }
    }

    

    IEnumerator StartBuying()
    {
        yield return new WaitForSeconds(delayBuy);
        PlayerControl.instance.ChangeMoney(-cost);

        SpawnNextZone();
    }

    public void SpawnNextZone()
    {
        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }
        buyZone.SetActive(false);

        nextZone.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER) && buyingCoroutine != null)
        {
            Debug.Log("Stop");
            StopCoroutine(buyingCoroutine);
        }
    }
}
