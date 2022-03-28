using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int Damage 
    { 
        get 
        {
            return _damage;
        }
    }

    public void DamageModifier(int modifier)
    {
        _damage += modifier;
    }
}