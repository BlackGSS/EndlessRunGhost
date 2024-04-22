using System.Collections.Generic;
using UnityEngine;

public class GenericDataPool<T, U> : MonoBehaviour where T : ItemSpawnable<U>
{
    [SerializeField] List<T> currentElements;

    public T SpawnElement(U data, T prefab)
    {
        if (currentElements.Count > 0)
        {
            for (int i = 0; i < currentElements.Count; i++)
            {
                if (!currentElements[i].gameObject.activeSelf)
                {
                    currentElements[i].SetData(data);
                    currentElements[i].Enable();
                    return currentElements[i];
                }
            }
            return AddElement(data, prefab);
        }
        else
        {
            return AddElement(data, prefab);
        }
    }

    protected virtual T AddElement(U data, T prefab)
    {
        T newElement = Instantiate(prefab, transform);
        newElement.SetData(data);
        currentElements.Add(newElement);
        return newElement;
    }

    public void DisableElement(T element)
    {
        element.Disable();
    }
}

public class ItemSpawnable<T> : MonoBehaviour
{
    public T data;
    public void SetData(T newData) => data = newData;
    public virtual void Enable() { gameObject.SetActive(true); }
    public virtual void Disable() { gameObject.SetActive(false); }
}
