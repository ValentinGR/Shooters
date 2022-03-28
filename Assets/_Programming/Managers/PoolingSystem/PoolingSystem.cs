using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    #region Arguments

    [SerializeField] private GameObject prefab;
    [SerializeField] private int nbrPoolObjects;
    private Queue<IPooleable> pooledObjects;

    #endregion

    #region Methods

    void Start()
    {
       CreatePool(); 
    }

    void CreatePool()
    {
        pooledObjects = new Queue<IPooleable>();

        int count = 0;

        while (count < nbrPoolObjects)
        {
            CreateANewInstance();
            
            count++;
        }
    }

    // Create and initialize a new Instance of "prefab"
    void CreateANewInstance()
    {
        IPooleable currentObj;

        currentObj = Instantiate(prefab, new Vector3(1000, 2000, 0), Quaternion.identity).GetComponent<IPooleable>();
        pooledObjects.Enqueue(currentObj);
        currentObj.Create(this);
    }

    // Dequeue an object and enable it
    public void AskAnObject(Vector3 position, Quaternion rotation)
    {
        if (pooledObjects.Count < 0)
            CreateANewInstance();
            
        IPooleable currentObject = pooledObjects.Dequeue();

        currentObject.Execute(position, rotation);
    }

    // Enqueue an object and disable it
    public void ReturnAnObject(IPooleable returnedObject)
    {
        pooledObjects.Enqueue(returnedObject);
        returnedObject.Disable();
    }

    public void ReturnAnObject(GameObject returnObject)
    {
        IPooleable pooleableComponent = returnObject.GetComponent<IPooleable>();
        if (pooleableComponent != null)
        {
            pooledObjects.Enqueue(pooleableComponent);
            pooleableComponent.Disable();
        }
    }

    #endregion
}