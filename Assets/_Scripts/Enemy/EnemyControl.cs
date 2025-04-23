using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class EnemyControl : UnitControl, IFactoryProduct, IStateUser
{
    public IStateUser user => this;
    public Stack<IFactoryProduct> pool { get; set; }
    public Rigidbody rb { get; private set; }
    public event Action<EnemyControl> BeingKilledEvent;
    public Vector3 shootHitOffset;

    public float CurrentSpeed;

    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage = new();

    public Animator animator { get; private set; }

    StateMachine stateMachine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        CurrentSpeed = unitStats.defaultSpeed;

        for (int i = 0; i < stateList.Count; i++)
        {
            stateStorage[stateList[i].state] = Instantiate(stateList[i]);
        }

        stateMachine = new(stateStorage[State.Move_Run], user);
    }


    public void Initialize()
    {
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
}
