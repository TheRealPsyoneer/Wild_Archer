using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : UnitControl, IStateUser
{
    public IStateUser user { get => this; }

    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage = new();
    public StateMachine stateMachine;

    private void Awake()
    {
        for (int i = 0; i < stateList.Count; i++)
        {
            stateStorage[stateList[i].state] = Instantiate(stateList[i]);
        }
    }

    private void Start()
    {
        stateMachine = new(stateStorage[State.Move_Run], this);
    }

    private void Update()
    {
        stateMachine.Execute();
    }
}
