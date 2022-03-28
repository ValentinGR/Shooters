using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : MonoBehaviour
{
    #region Events

    public static event Action<Vector3, Quaternion> onFire;
    public event Action<int> onBulletsNumberChange;

    #endregion

    #region Arguments

    private short m_ammunition;

    [SerializeField] private short m_damage;
    [SerializeField] private float m_fireRange;
    [SerializeField] private float m_fireRate;
    private float timeLastFire;

    [SerializeField] private short m_maxAmmunition;
    private short m_Ammunition
    {
        get
        {
            return m_ammunition;
        }
        set
        {
            if (value > m_maxAmmunition)
                m_ammunition = m_maxAmmunition;
            else if (value < 0)
                m_ammunition = 0;
            else
                m_ammunition = value;
        }
    }

    // Références
    private Bullets m_projectiles;
    private Transform m_target;
    [SerializeField] private Vector3 m_fireLaunchOffset;
    
    #endregion

    #region Constructors

    public Weapons(short damage, float fireRange, float fireRate, short ammunition, Bullets projectiles)
    {
        m_damage = damage;
        m_fireRange = fireRange;
        m_fireRate = fireRate;
        m_maxAmmunition = ammunition;

        m_Ammunition = m_maxAmmunition;

        m_projectiles = projectiles;
    }

    public Weapons(short damage, float fireRange, float fireRate, short ammunition, Bullets projectiles, Vector3 offset)
    {
        m_damage = damage;
        m_fireRange = fireRange;
        m_fireRate = fireRate;
        m_maxAmmunition = ammunition;

        m_Ammunition = m_maxAmmunition;

        m_projectiles = projectiles;
        m_fireLaunchOffset = offset;
    }

    #endregion

    #region Methods

    void Awake()
    {
        if (m_Ammunition == 0)
            m_Ammunition = m_maxAmmunition;

        onBulletsNumberChange?.Invoke(m_Ammunition);
    }

    public virtual void DefineTarget(Transform target)
    {
        m_target = target;
    }

    public virtual int Fire() // 0 == No Ammunition // 1 == Fire OK // 2 == Need to Wait for FireRate
    {
        if (Time.time - timeLastFire < m_fireRate)
            return 2;

        if (m_Ammunition <= 0)
            return 0;

        timeLastFire = Time.time;
        m_Ammunition--;
        onFire?.Invoke(transform.position + transform.up * m_fireLaunchOffset.x, transform.rotation);
        onBulletsNumberChange?.Invoke(m_Ammunition);

        return 1;
    }

    public void Reload()
    {
        m_Ammunition = m_maxAmmunition;
        onBulletsNumberChange?.Invoke(m_Ammunition);
    }

    #endregion
}