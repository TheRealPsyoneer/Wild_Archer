using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : HealthBar
{
    DamageReceiver damageReceiver;
    [SerializeField] float showUITime;

    Coroutine turnOffUICoroutine;

    protected override void Awake()
    {
        base.Awake();
        damageReceiver = GetComponentInParent<DamageReceiver>();

        damageReceiver.UnitGotHit += ShowHealthBarUI;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    void ShowHealthBarUI()
    {

        if (turnOffUICoroutine != null)
        {
            StopCoroutine(turnOffUICoroutine);
        }

        currentHealthSlider.gameObject.SetActive(true);
        turnOffUICoroutine = StartCoroutine(TurnOffUI());
    }

    IEnumerator TurnOffUI()
    {
        yield return new WaitForSeconds(showUITime);
        currentHealthSlider.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        currentHealthSlider.gameObject.SetActive(false);
    }
}
