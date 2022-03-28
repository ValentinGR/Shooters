using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWaveEndState : IGameManagerState
{
    #region Events Subscription

    public WaitWaveEndState()
    {
        UnitStateMachine.onUnitDie += EnemyDeath;
    }

    ~WaitWaveEndState()
    {
        UnitStateMachine.onUnitDie -= EnemyDeath;
    }

    #endregion

    #region Arguments

    private int _nbrOfEnemiesAlives;

    #endregion

    #region Methods

    void EnemyDeath(string objectTag)
    {
        if (objectTag == "Enemy")
            _nbrOfEnemiesAlives--;
    }

        #region IGameManagerState Methods

    public void Enter(GameManager gameManager)
    {
        _nbrOfEnemiesAlives = gameManager.nbrOfWaves * 5;
    }

    public void Execute(GameManager gameManager)
    {
        if (_nbrOfEnemiesAlives <= 0)
            gameManager.ChangeState(gameManager.generateEnemyState);
    }

    public void Exit(GameManager gameManager)
    {
        _nbrOfEnemiesAlives = 0;
    }

        #endregion

    #endregion
}