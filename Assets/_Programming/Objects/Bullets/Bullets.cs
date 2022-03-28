using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Damaging))]
[RequireComponent(typeof(OutOfScreen))]
public class Bullets : MonoBehaviour, IPooleable
{
    #region Arguments

    private bool m_isMoving;
    
    // References
    PoolingSystem m_poolingSystem;
    Movement m_movement;

    #endregion

    #region Methods

    void Awake()
    {
        m_movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (m_isMoving)
            m_movement.Move();
    }

        #region IPooleable Interface Methods

    // Initialize Object
    public void Create(PoolingSystem poolingSystem)
    {
        m_poolingSystem = poolingSystem;
        transform.parent = m_poolingSystem.gameObject.transform;

        Disable();
    }

    // Enable Object
    public void Execute(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        m_movement.DefineDirection(new Vector2(transform.up.x, transform.up.y));

        m_isMoving = true;
    }

    // Disable Object
    public GameObject Disable()
    {
        transform.position = new Vector3(1000, 1000, 1000);

        m_isMoving = false;

        return this.gameObject;
    }

        #endregion

    #endregion
}