using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element3DDataPool<T, U> : GenericDictionaryDataPool<T, U> where T : ItemSpawnable<U>
{
    private Transform targetPos;

    public T SpawnElement(U data, T prefab, Transform parentPosition)
    {
        targetPos = parentPosition;
        T newElement = SpawnElement(data, prefab);
        UpdatePosition(newElement);
        return newElement;
    }

    private void UpdatePosition(T element)
    {
        element.transform.position = targetPos.position;
    }

    protected override T AddElement(U data, T prefab)
    {
        T newElement = base.AddElement(data, prefab);
        UpdatePosition(newElement);
        return newElement;
    }
}
