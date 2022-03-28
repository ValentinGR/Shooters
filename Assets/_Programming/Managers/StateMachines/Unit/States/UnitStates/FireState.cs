using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : IUnitState
{
    public void Enter(UnitStateMachine unitStateMachine)
    {
        int fireValue = unitStateMachine._weapons.Fire();
        
        if (fireValue == 0)
            unitStateMachine.ChangeState(unitStateMachine.reloadAndMove);
        else
            unitStateMachine.ChangeState(unitStateMachine.idleState);
    }

    public void Execute(UnitStateMachine unitStateMachine)
    {

    }

    public void Exit(UnitStateMachine unitStateMachine)
    {
        
    }
}