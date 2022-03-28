using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : CollisionType
{
    public override void CollisionDetected(string collisionTag, GameObject currentObject)
    {
        BulletsPooling.Instance.ReturnAnObject(currentObject.GetComponent<IPooleable>());
    }
}