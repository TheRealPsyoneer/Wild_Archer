using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateNode : ScriptableObject
{
    public IStateUser user;
    public State state;
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
