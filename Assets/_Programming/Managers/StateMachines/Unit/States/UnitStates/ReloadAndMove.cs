using UnityEngine;

public class ReloadAndMove : IUnitState
{
    public float animationNormalizedTime { get ; private set ; }
    public void Enter(UnitStateMachine unitStateMachine)
    {
        unitStateMachine.weaponsAnimator.Play("Base Layer.Gun_Reload", 0, 0);
        int layer = unitStateMachine.weaponsAnimator.GetLayerIndex("Base Layer");
        animationNormalizedTime = unitStateMachine.weaponsAnimator.GetCurrentAnimatorStateInfo(layer).length;
    }

    public void Execute(UnitStateMachine unitStateMachine)
    {
        unitStateMachine.movement.DefineDirection(unitStateMachine.direction);
        unitStateMachine.movement.LookAtTarget(unitStateMachine.aimDirection);
        unitStateMachine.movement.Move();

        animationNormalizedTime -= Time.deltaTime;

        if (animationNormalizedTime <= 0)
            unitStateMachine.ChangeState(unitStateMachine.idleState);
    }

    public void Exit(UnitStateMachine unitStateMachine)
    {
        unitStateMachine.weapons.Reload();
    }
}