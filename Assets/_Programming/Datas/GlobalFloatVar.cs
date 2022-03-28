using UnityEngine;
using System;

[CreateAssetMenu(menuName = ("Datas/GlobalVariables/Float"), fileName = ("New Global Float Variables"))]
public class GlobalFloatVar : ScriptableObject
{
    private float _value;
    public float Value 
    { 
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            onChangeValue?.Invoke(_value);
        }
    }
    public event Action<float> onChangeValue;
}