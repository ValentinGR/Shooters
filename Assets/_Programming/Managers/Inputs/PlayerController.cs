using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    private UnitStateMachine _unitStateMachine;

    private bool isMovementPressed = false;
    private Vector2 movementVector;
    private Vector2 aimVector;

    void Awake()
    {
        _unitStateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitStateMachine>();
    }

    void Update()
    {
        _unitStateMachine.DefineDirection(movementVector, aimVector);
    }

    public void MovementInputs(InputAction.CallbackContext context)
    {
        if (context.performed)
            isMovementPressed = true;
            
        if (context.canceled)
            isMovementPressed = false;
            
        movementVector = context.ReadValue<Vector2>();
        movementVector = new Vector2(movementVector.x.SignedValueTo1(), movementVector.y.SignedValueTo1());
    }

    public void FireInputs(InputAction.CallbackContext context)
    {
        if (!_playerInput.inputIsActive)
            return;

        if (context.performed)
            _unitStateMachine.ChangeState(_unitStateMachine.fireState);
    }

    public void ReloadInputs(InputAction.CallbackContext context)
    {
        if (!_playerInput.inputIsActive)
            return;
            
        if (context.performed)
            _unitStateMachine.ChangeState(_unitStateMachine.reloadAndMove);
    }

    public void AimInputs(InputAction.CallbackContext context)
    {
        if (!_playerInput.inputIsActive)
            return;

        if (context.canceled)
            return;

        aimVector = context.ReadValue<Vector2>();
        aimVector = Camera.main.ScreenToWorldPoint(aimVector) - _unitStateMachine.gameObject.transform.position;
    }
}