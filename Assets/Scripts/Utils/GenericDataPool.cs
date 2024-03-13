using System.Collections.Generic;
using UnityEngine;

public class GenericDataPool<T, U> : MonoBehaviour where T : ItemSpawnable<U>
{
    [SerializeField] List<T> currentElements;

    //TODO: Pass parent, the parent will be a point in the current chunk
    public T SpawnElement(U data, T prefab, Transform parentPosition)
    {
        if (currentElements.Count > 0)
        {
            for (int i = 0; i < currentElements.Count; i++)
            {
                if (!currentElements[i].gameObject.activeSelf)
                {
                    currentElements[i].Initialize(data);
                    currentElements[i].Enable();
                    UpdatePosition(currentElements[i], parentPosition);
                    return currentElements[i];
                }
            }
            return AddElement(data, prefab, parentPosition);
        }
        else
        {
            return AddElement(data, prefab, parentPosition);
        }
    }

    public T AddElement(U data, T prefab, Transform parentPosition)
    {
        T newElement = Instantiate(prefab, transform);
        UpdatePosition(newElement, parentPosition);
        newElement.Initialize(data);
        currentElements.Add(newElement);
        return newElement;
    }

    private void UpdatePosition(T element, Transform newPos)
    {
        element.transform.position = newPos.position;
    }

    public void DisableElement(T element)
    {
        element.Disable();
    }
}

public class ItemSpawnable<T> : MonoBehaviour
{
    public T data;
    public void Initialize(T newData) => data = newData;
    public virtual void Enable() { gameObject.SetActive(true); }
    public virtual void Disable() { gameObject.SetActive(false); }
}
