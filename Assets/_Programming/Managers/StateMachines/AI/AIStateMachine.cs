using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    #region Events Subscription

    void OnEnable()
    {
        determineTargetPosition.onDefineTargetPosition += DefineTargetPos;
    }

    void OnDisable()
    {
        determineTargetPosition.onDefineTargetPosition -= DefineTargetPos;
    }

    #endregion

    #region Arguments

    public static Transform _playerTransform { get ; private set ; }

    public Transform myTransform { get ; private set ; }
    public Vector3 targetPosition { get ; private set ; }
    

    IAIState currentState;

    public UnitStateMachine unitStateMachine { get ; private set ; }

    // States :

    public DetermineTargetPosition determineTargetPosition = new DetermineTargetPosition();
    public CheckDistanceToTarget checkDistanceToTarget = new CheckDistanceToTarget();
    public DefineAttackAngle defineAttackAngle = new DefineAttackAngle();

    #endregion

    #region Methods

    void Awake()
    {
        myTransform = transform;
        if (_playerTransform == null)
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        unitStateMachine = GetComponent<UnitStateMachine>();
        
        ChangeState(determineTargetPosition);
    }

        #region State Machine Methods

    void Update()
    {
        currentState.Execute(this);
    }

    public void ChangeState(IAIState newState)
    {       
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;
        currentState.Enter(this);
    }

        #endregion

    void DefineTargetPos(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    #endregion
}