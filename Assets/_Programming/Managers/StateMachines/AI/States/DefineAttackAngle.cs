using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineAttackAngle : IAIState
{
    public void Enter(AIStateMachine aiStateMachine)
    {
        
    }

    public void Execute(AIStateMachine aiStateMachine)
    {
        aiStateMachine.unitStateMachine.DefineDirection(Vector3.zero, AIStateMachine._playerTransform.position - aiStateMachine.myTransform.position);
        aiStateMachine.unitStateMachine.movement.LookAtTarget(aiStateMachine.unitStateMachine.aimDirection);
        aiStateMachine.unitStateMachine.ChangeState(aiStateMachine.unitStateMachine.fireState);
    }

    public void Exit(AIStateMachine aiStateMachine)
    {
        
    }
}