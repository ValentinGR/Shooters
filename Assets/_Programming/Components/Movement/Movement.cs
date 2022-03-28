using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Arguments

    private Vector2 _direction;

    private Transform _toMove;
    public MovementLimitation _movementLimitation;

    public float Speed;

    #endregion

    #region Initialisation

    void Awake()
    {
        _toMove = transform;
    }

    #endregion

    #region Methods

    public void DefineDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void Move()
    {
        _toMove.position += new Vector3(_direction.x, _direction.y, 0) * Speed * Time.deltaTime; 
        _movementLimitation.LimitateMovement(_toMove);
    }

    public void LookAtTarget(Vector2 aimDirection)
    {
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _toMove.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    #endregion
}