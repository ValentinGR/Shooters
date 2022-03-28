using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPooling : PoolingSystem
{
    #region Singleton

    public static BulletsPooling Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    #region Events Subscriptions

    void OnEnable()
    {
        Weapons.onFire += AskAnObject;
        OutOfScreen.onGettingOutOfScreen += ReturnAnObject;
    }

    void OnDisable()
    {
        Weapons.onFire -= AskAnObject;
        OutOfScreen.onGettingOutOfScreen -= ReturnAnObject;
    }

    #endregion   
}