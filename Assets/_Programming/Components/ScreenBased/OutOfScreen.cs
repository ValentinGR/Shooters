using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutOfScreen : MonoBehaviour
{
    #region Events

    public static event Action<GameObject> onGettingOutOfScreen;

    #endregion

    #region Arguments

    private Transform _transform;
    private Camera _mainCamera;
    private bool _inScreen = false;

    #endregion

    #region Methods

        #region Initialisation
    void Awake()
    {
        _mainCamera = Camera.main;
        _transform = transform;
    }

        #endregion

    void Update()
    {
        bool testIfInScreen = CheckIfInScreen();
        if (_inScreen && !testIfInScreen)
            onGettingOutOfScreen?.Invoke(this.gameObject);

        _inScreen = testIfInScreen;
    }

    bool CheckIfInScreen()
    {
        Vector2 testedPosition = new Vector2 (Mathf.Abs(_transform.position.x), Mathf.Abs(_transform.position.y));
        testedPosition = _mainCamera.WorldToScreenPoint(testedPosition);

        if (testedPosition.x > Screen.width || testedPosition.y > Screen.height)
            return false;
        
        return true;
    }

    #endregion
}