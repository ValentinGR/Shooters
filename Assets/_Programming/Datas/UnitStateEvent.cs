using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = ("Events/UnitStateEvent"), fileName = ("New Unit State Event"))]
public class UnitStateEvent : ScriptableObject
{
    public UnityEvent onNewState;
}