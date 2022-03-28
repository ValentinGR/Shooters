using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPooling : PoolingSystem
{
    #region Singleton

    public EnemiesPooling Instance { get ; private set ; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    #region Events Subscription

    void OnEnable()
    {
        GenerateEnemyState.onSpawnEnemy += AskAnObject;
    }

    void OnDisable()
    {
        GenerateEnemyState.onSpawnEnemy -= AskAnObject;
    }

    #endregion
}