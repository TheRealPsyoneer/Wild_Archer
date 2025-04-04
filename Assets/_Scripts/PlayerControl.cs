using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IStateUser
{
    public static PlayerControl instance { get; private set; }
    public IStateUser user { get => this; }

    public PlayerStats stats { get; set; }

    public float speed { get; set; }
    public Vector2 direction { get; set; }
    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage { get; set; } = new();
    public StateMachine stateMachine { get; set; }
    public Animator animator { get; set; }

    public Transform skin { get; set; }
    public int skinIndex { get; set; } = 1;
    public CharacterController characterController { get; set; }

    const float GRAVITY_FORCE = 9.81f;

    private void Awake()
    {
        instance = this;
        for (int i=0; i < stateList.Count; i++)
        {
            stateStorage[stateList[i].state] = stateList[i];
        }

        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        stateMachine = new(stateStorage[State.Idle], this);
        skin = SkinManager.instance.skins[skinIndex];
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    public void ChangeStateTo(State state)
    {
        stateMachine.TransitionTo(stateStorage[state]);
    }
}
