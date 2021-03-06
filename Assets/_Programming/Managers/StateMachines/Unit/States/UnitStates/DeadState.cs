using UnityEngine;
using System;

public class DeadState : IUnitState
{
    private float _timeSinceDeath;

    public void Enter(UnitStateMachine unitStateMachine)
    {
        unitStateMachine.movement.DefineDirection(-unitStateMachine.transform.position.normalized);
        _timeSinceDeath = 0;
    }

    public void Execute(UnitStateMachine unitStateMachine)
    {
        _timeSinceDeath += Time.deltaTime;
        if (_timeSinceDeath < 0.5f)
            unitStateMachine.movement.Move();
    }

    public void Exit(UnitStateMachine unitStateMachine)
    {
        
    }
}