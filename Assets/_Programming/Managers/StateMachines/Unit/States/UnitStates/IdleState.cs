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
        unitStateMachine._movement.DefineDirection(unitStateMachine.direction);
        unitStateMachine._movement.LookAtTarget(unitStateMachine.aimDirection);
        unitStateMachine._movement.Move();
    }

    public void Exit(UnitStateMachine unitStateMachine)
    {
        
    }
}