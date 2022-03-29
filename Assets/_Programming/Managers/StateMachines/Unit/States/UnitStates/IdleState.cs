using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IUnitState
{
    public void Enter(UnitStateMachine unitStateMachine)
    {

    }

    public void Execute(UnitStateMachine unitStateMachine)
    {
        unitStateMachine.movement.DefineDirection(unitStateMachine.direction);
        unitStateMachine.movement.LookAtTarget(unitStateMachine.aimDirection);
        unitStateMachine.movement.Move();
    }

    public void Exit(UnitStateMachine unitStateMachine)
    {
        
    }
}