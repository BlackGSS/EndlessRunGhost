using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericDictionaryDataPool<T, U> : MonoBehaviour where T : ItemSpawnable<U>
{
    [SerializeField] Dictionary<U, List<T>> elements = new Dictionary<U, List<T>>();

    public T SpawnElement(U data, T prefab)
    {
        if (elements.Count > 0)
        {
            if (elements.TryGetValue(data, out List<T> value))
            {
                if (value.Where(x => !x.gameObject.activeSelf).Count() > 0)
                {
                    for (int i = 0; i < value.Count; i++)
                    {
                        if (!value[i].gameObject.activeSelf)
                        {
                                    value[i].Enable();
                                    return value[i];
                        }
                    }
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
        if (elements.ContainsKey(data))
            elements[data].Add(newElement);
        else
            elements.Add(data, new List<T>() { newElement });
        return newElement;
    }

    public void DisableElement(T element)
    {
        element.Disable();
    }
}
