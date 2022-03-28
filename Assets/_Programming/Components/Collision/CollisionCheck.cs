using UnityEngine;
using System;

public class CollisionCheck : MonoBehaviour
{
    #region Events

    public event Action<int> onCollision;

    #endregion

    public CollisionType collisionType;

    void OnTriggerEnter(Collider other)
    {
        Damaging damaging = other.GetComponent<Damaging>(); 
        if (damaging != null)
            onCollision?.Invoke(-damaging.Damage);
            
        if (collisionType != null)
            collisionType.CollisionDetected(other.tag, gameObject);
    }
}