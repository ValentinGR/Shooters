using UnityEngine;
using System;

public class DetermineTargetPosition : IAIState
{
    #region Events

    public event Action<Vector3> onDefineTargetPosition;

    #endregion

    public void Enter(AIStateMachine aiStateMachine)
    {
        Vector3 targetPosition = Vector3.zero;
        onDefineTargetPosition?.Invoke(targetPosition);
        aiStateMachine.ChangeState(aiStateMachine.checkDistanceToTarget);
    }

    public void Execute(AIStateMachine aiStateMachine)
    {
        
    }

    public void Exit(AIStateMachine aiStateMachine)
    {
        
    }
}