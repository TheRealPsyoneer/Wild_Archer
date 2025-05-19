using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.AI;

public class EnemyControl : UnitControl, IFactoryProduct, IStateUser
{
    [SerializeField] ParticleSystem bloodVFX;

    public IStateUser user => this;
    public Stack<IFactoryProduct> pool { get; set; }
    public Rigidbody rb { get; private set; }
    public event Action<EnemyControl> BeingKilledEvent;
    public Vector3 shootHitOffset;

    public float CurrentSpeed;
    public float CurrentDamage;

    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage = new();

    public Animator animator { get; private set; }

    StateMachine stateMachine;
    DamageReceiver damageReceiver;

    Health health;
    public float CurrentHealth => health.CurrentHealth;

    public NavMeshAgent nav { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        damageReceiver = GetComponent<DamageReceiver>();
        health = GetComponent<Health>();
        nav = GetComponent<NavMeshAgent>();

        damageReceiver.UnitGotHit += OnGettingHit;

        

        for (int i = 0; i < stateList.Count; i++)
        {
            stateStorage[stateList[i].state] = Instantiate(stateList[i]);
        }

        stateMachine = new(stateStorage[State.Move_Run], user);
    }

    void OnGettingHit()
    {
        if (stateMachine.currentState.state != State.GetHit && stateMachine.currentState.state != State.Death)
        {
            ChangeStateTo(State.GetHit);
        }
    }

    public void Initialize()
    {
        CurrentSpeed = unitStats.defaultSpeed;
        CurrentDamage = unitStats.defaultDamage;

        health.ChangeHealth(unitStats.defaultHealth);
        ChangeStateTo(State.Move_Run);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    public void ChangeStateTo(State state)
    {
        stateMachine.TransitionTo(stateStorage[state]);
    }

    public State GetCurrentState()
    {
        return stateMachine.currentState.state;
    }

    private void OnDisable()
    {
        BeingKilledEvent?.Invoke(this);
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        pool.Push(this);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ShowBloodVFX()
    {
        bloodVFX.Play();
    }
}
