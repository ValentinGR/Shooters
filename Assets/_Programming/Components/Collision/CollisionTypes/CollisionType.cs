using UnityEngine;
using System;

public abstract class CollisionType : MonoBehaviour
{
    public abstract void CollisionDetected(string collisionTag, GameObject currentObject);
}