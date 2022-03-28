using UnityEngine;
using System;

public class GenerateEnemyState : IGameManagerState
{
    #region Events

    public static event Action<Vector3, Quaternion> onSpawnEnemy;
    public static event Action<int> onBeginNewWave;

    #endregion

    #region Arguments

    private float _timeBtwEnemy;
    private float _lastSpawnTime;
    public int _nbrOfEnemies{get ; private set;}
    private float _spawningRadius = 13;

    #endregion

    #region Methods

        #region IGameManagerState Methods

    public void Enter(GameManager gameManager)
    {
        onBeginNewWave?.Invoke(gameManager.nbrOfWaves);

        _nbrOfEnemies = 5 * (gameManager.nbrOfWaves + 1);
        
        _timeBtwEnemy = 5f - 0.3f * gameManager.nbrOfWaves;
        if (_timeBtwEnemy < 0.5f)
            _timeBtwEnemy = 0.5f;

        _lastSpawnTime = Time.time;
    }

    public void Execute(GameManager gameManager)
    {
        if (_timeBtwEnemy > Time.time - _lastSpawnTime)
            return;

        SpawnAEnemy();

        _nbrOfEnemies--;
        _lastSpawnTime = Time.time;
    
        if (_nbrOfEnemies <= 0)
            gameManager.ChangeState(gameManager.waitWaveEndState);
    }

    public void Exit(GameManager gameManager)
    {
        gameManager.ChangeWaveNumber(gameManager.nbrOfWaves + 1);
    }

        #endregion

    void SpawnAEnemy()
    {
        float xLenght = UnityEngine.Random.Range(-1f, 1f);
        float yLenght = (1 - Mathf.Abs(xLenght)) * 1.RandomSign();

        Vector2 direction = new Vector2(xLenght, yLenght);
        Vector2 spawnPoint = direction * _spawningRadius;

        onSpawnEnemy?.Invoke(new Vector3(spawnPoint.x, spawnPoint.y, 0), Quaternion.identity);
    }

    #endregion
}
