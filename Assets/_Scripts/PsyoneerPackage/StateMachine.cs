using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IStateUser user { get; private set; }
    public StateNode currentState { get; private set; }

    public StateMachine(StateNode enterState, IStateUser user)
    {
        this.user = user;
        currentState = enterState;
        currentState.user = user;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState.Execute();
    }

    public void TransitionTo(StateNode nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.user = user;
        currentState.Enter();
    }
}
