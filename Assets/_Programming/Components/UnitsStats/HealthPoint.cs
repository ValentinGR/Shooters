using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CollisionCheck))]
public class HealthPoint : MonoBehaviour
{
    #region Events Subscription

    void OnEnable()
    {
        GetComponent<CollisionCheck>().onCollision += ModifyHP;
    }

    void OnDisable()
    {
        GetComponent<CollisionCheck>().onCollision -= ModifyHP;
    }

    #endregion

    #region Events

    public event Action onDeath;
    public event Action<int> onHPChange;

    #endregion

    private int m_hp;
    public int HP 
    {
        get
        {
            return m_hp;
        } 
        private set
        {
            if (value <= 0)
            {
                m_hp = 0;
                onDeath?.Invoke();
            }
            else if (value > maxHP)
                m_hp = maxHP;
            else
                m_hp = value;
        }
    }
    [SerializeField] private int maxHP;

    void Awake()
    {
        ResetHP();
    }

    public void ModifyHP(int modifier)
    {
        HP += modifier;
        onHPChange?.Invoke(HP);
    }

    public void ResetHP()
    {
        HP = maxHP;
        onHPChange?.Invoke(HP);
    }
}