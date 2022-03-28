using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : UnitStateMachine, IPooleable
{
    #region Events Subscription

    void OnEnable()
    {
        _hp.onDeath += ReturnToPool;
    }

    void OnDisable()
    {
        _hp.onDeath -= ReturnToPool;
    }

    #endregion

    #region Arguments

    private bool _isActive;
    private PoolingSystem _poolingSystem;
    private AIStateMachine _aiStateMachine;

    #endregion

    #region IPooleable Interface Methods

    // Initialize Object
    public void Create(PoolingSystem poolingSystem)
    {
        _poolingSystem = poolingSystem;
        transform.parent = _poolingSystem.gameObject.transform;
        _aiStateMachine = GetComponent<AIStateMachine>();

        Disable();
    }

    // Enable Object
    public void Execute(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        _isActive = true;

        _aiStateMachine.ChangeState(_aiStateMachine.determineTargetPosition);
    }

    // Disable Object
    public GameObject Disable()
    {
        transform.position = new Vector3(2000, 1000, 1000);

        _isActive = false;

        return this.gameObject;
    }

    void ReturnToPool()
    {
        _hp.ResetHP();
        _poolingSystem.ReturnAnObject(this);
    }

    #endregion
}