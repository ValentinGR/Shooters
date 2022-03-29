using UnityEngine;
using System;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(HealthPoint))]
[RequireComponent(typeof(CollisionCheck))]
public class UnitStateMachine : MonoBehaviour
{
    #region Events

    public static event Action<string> onUnitDie;

    #endregion

    #region Events Subscription

    void OnDisable()
    {
        hp.onDeath -= ChangeToDeathState;
    }

    #endregion

    #region Arguments

    public Vector2 direction { get ; private set ; }
    public Vector2 aimDirection { get ; private set ; }

    public Animator weaponsAnimator { get ; private set ; }

    public Weapons weapons { get ; private set ; }
    public Movement movement { get ; private set ; }
    public HealthPoint hp { get ; private set ; }
    public CollisionCheck collisionCheck { get ; private set ; }


    public IUnitState currentState { get ; private set ;}

    // States :

    public DeadState deadState = new DeadState();
    public IdleState idleState = new IdleState();
    public FireState fireState = new FireState();
    public ReloadAndMove reloadAndMove = new ReloadAndMove();

    #endregion

    #region Initialisation

    void Awake()
    {
        movement = GetComponent<Movement>();
        weapons = GetComponentInChildren<Weapons>();
        hp = GetComponent<HealthPoint>();
        collisionCheck = GetComponent<CollisionCheck>();

        hp.onDeath += ChangeToDeathState;

        weaponsAnimator = weapons.gameObject.GetComponent<Animator>();

        ChangeState(idleState);
    }

    #endregion

    #region Methods

        #region State Machine Methods

    void Update()
    {
        currentState.Execute(this);
    }

    public void ChangeState(IUnitState newState)
    {
        if (currentState == reloadAndMove && newState != deadState && reloadAndMove.animationNormalizedTime > 0)
            return;
            
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;
        currentState.Enter(this);
    }
    
        #endregion

    

    void ChangeToDeathState()
    {
        onUnitDie?.Invoke(this.gameObject.tag);
        ChangeState(deadState);
    }

    public void DefineDirection(Vector2 direction, Vector2 aimDirection)
    {
        this.direction = direction;
        this.aimDirection = aimDirection;
    }

    #endregion
}