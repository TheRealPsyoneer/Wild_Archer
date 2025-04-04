using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IStateUser
{
    public static PlayerControl instance;
    public IStateUser user { get => this; }

    public PlayerStats stats;

    public float speed { get; private set; }
    public Vector2 direction { get; private set; }
    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage = new();
    public StateMachine stateMachine;
    public Animator animator { get; private set; }

    public Transform skin { get; private set; }
    public int skinIndex = 1;
    public CharacterController characterController { get; private set; }

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

    public void UpdateSpeed()
    {
        speed = stats.speed;
        animator.SetFloat("Speed", speed);
    }

    public void ResetSpeed()
    {
        speed = 0;
        animator.SetFloat("Speed", 0);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
