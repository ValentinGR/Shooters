public interface IUnitState 
{
    void Enter(UnitStateMachine unitStateMachine);
    void Execute(UnitStateMachine unitStateMachine);
    void Exit(UnitStateMachine unitStateMachine);
}

public interface IAIState
{
    void Enter(AIStateMachine aiStateMachine);
    void Execute(AIStateMachine aiStateMachine);
    void Exit(AIStateMachine aiStateMachine);
}

public interface IGameManagerState
{
    void Enter(GameManager gameManager);
    void Execute(GameManager gameManager);
    void Exit(GameManager gameManager);
}