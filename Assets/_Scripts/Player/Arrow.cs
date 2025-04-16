using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow : MonoBehaviour, IFactoryProduct
{
    [SerializeField] ArrowStats stats;
    Rigidbody rb;
    public PlayerControl player { get; set; }
    public float CurrentDamage { get; private set; }
    public float CurrentFlyingTime { get; private set; }
    public Stack<IFactoryProduct> pool { get; set; }
    public EnemyControl enemy { get; set; }

    private void Awake()
    {
        CurrentDamage = stats.defaultDamage;
        CurrentFlyingTime = stats.defaultFlyingTime;

        rb = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }

    public void Shooting()
    {
        Vector3 lookDirection = (player.currentTarget.transform.position - player.transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(lookDirection.x, lookDirection.z));
        transform.rotation = Quaternion.Euler(0, -angle, 0);

        rb.DOMove(enemy.transform.position, CurrentFlyingTime).OnComplete(() => gameObject.SetActive(false));
    }

    private void OnDisable()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        pool.Push(this);
    }
}
