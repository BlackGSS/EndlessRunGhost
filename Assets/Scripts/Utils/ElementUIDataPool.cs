using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementUIDataPool<T, U> : GenericDataPool<T, U> where T : ItemSpawnable<U>
{
    [SerializeField] T prefab;
    [SerializeField] Transform parentTransform;
    
    public T SpawnElement(U data)
    {
        T newElement = SpawnElement(data, prefab);
        newElement.transform.SetParent(parentTransform);
        return newElement;
    }
}
