using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Events

    void OnEnable()
    {
        
        _playerObject.GetComponent<HealthPoint>().onDeath += ChangeToDeadState;
    }

    void OnDisable()
    {
        if (_playerObject != null)
            _playerObject.GetComponent<HealthPoint>().onDeath -= ChangeToDeadState;
    }

    #endregion

    #region Arguments

    public int nbrOfWaves { get ; private set ;}

    public GenerateEnemyState generateEnemyState = new GenerateEnemyState();
    public WaitWaveEndState waitWaveEndState = new WaitWaveEndState();
    public EndGameState endGameState = new EndGameState();

    private GameObject _playerObject;

    #endregion

    #region Initialisation

    void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");

        ChangeWaveNumber(0);
        ChangeState(generateEnemyState);
    }

    #endregion


    #region Methods

        #region State Machine

    IGameManagerState currentState;

    public void ChangeState(IGameManagerState newState)
    {
        if (currentState != null)
            currentState.Exit(this);
            
        currentState = newState;
        currentState.Enter(this);
    }

    public void ExecuteCurrentState()
    {
        if (currentState != null)
            currentState.Execute(this);
    }

        #endregion

    void Update()
    {
        ExecuteCurrentState();
    }

    public void ChangeWaveNumber(int value)
    {
        nbrOfWaves = value;
    }

    void ChangeToDeadState()
    {
        _playerObject.GetComponent<BoxCollider>().enabled = false;
        ChangeState(endGameState);
    }

    #endregion

}