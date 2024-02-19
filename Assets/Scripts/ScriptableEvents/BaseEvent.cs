using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neisum.ScriptableEvents
{
    public abstract class BaseEvent<T> : ScriptableObject
    {
        private List<IScriptableEventListener<T>> listeners = new List<IScriptableEventListener<T>>();
        public T overloadData;

        public void Raise(T data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(data);
            }
        }

        public void RegisterListener(IScriptableEventListener<T> listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(IScriptableEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}