using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceToTarget : IAIState
{
    private Vector3 _targetPosition;
    private float _distanceToCenter;
    public void Enter(AIStateMachine aiStateMachine)
    {
        _distanceToCenter = Random.Range(2f, 4f);
        _targetPosition = aiStateMachine.targetPosition;
        aiStateMachine.unitStateMachine.DefineDirection((_targetPosition - aiStateMachine.myTransform.position).normalized, (_targetPosition - aiStateMachine.myTransform.position).normalized);
    }

    public void Execute(AIStateMachine aiStateMachine)
    {
        if (Vector3.Distance(_targetPosition, aiStateMachine.myTransform.position) <= _distanceToCenter)
            aiStateMachine.ChangeState(aiStateMachine.defineAttackAngle);
    }

    public void Exit(AIStateMachine aiStateMachine)
    {
        aiStateMachine.unitStateMachine.DefineDirection(Vector3.zero, _targetPosition);
    }
}