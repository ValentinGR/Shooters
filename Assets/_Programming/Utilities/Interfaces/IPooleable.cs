using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleable
{
    void Create(PoolingSystem poolingSystem);
    void Execute(Vector3 position, Quaternion rotation);
    GameObject Disable();
}