using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : UnitControl, IStateUser
{
    public static PlayerControl instance;
    public IStateUser user { get => this; }

    public PlayerStats playerStats;

    public float speed { get; private set; }
    public Vector2 direction { get; private set; }
    [SerializeField] List<StateNode> stateList;
    public Dictionary<State, StateNode> stateStorage = new();
    public StateMachine stateMachine;
    public Animator animator { get; private set; }

    public Transform skin { get; private set; }
    public int skinIndex = 1;
    public CharacterController characterController { get; private set; }
    public EnemyControl currentTarget { get; private set; }
    public ProjectileShooter shooter { get; private set; }
    public Health playerHeath { get; private set; }

    public Vector3 shootPositionOffset;

    public NavMeshAgent navMeshAgent { get; private set; }

    const float GRAVITY_FORCE = 9.81f;

    public bool isShooting;

    

    private void Awake()
    {
        instance = this;
        for (int i=0; i < stateList.Count; i++)
        {
            stateStorage[stateList[i].state] = Instantiate(stateList[i]);
        }

        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        shooter = GetComponent<ProjectileShooter>();
        playerHeath = GetComponent<Health>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        playerHeath.HealthChanged += CheckHealth;
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

    public State GetCurrentState()
    {
        return stateMachine.currentState.state;
    }

    public void UpdateSpeed(float ratio)
    {
        speed = unitStats.defaultSpeed * ratio;
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

    public void SetTarget(EnemyControl enemy)
    {
        currentTarget = enemy;
    }

    void CheckHealth()
    {
        if (playerHeath.CurrentHealth <= 0)
        {
            ChangeStateTo(State.Death);
        }
    }
}
