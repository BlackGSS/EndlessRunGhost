using System;
using System.Collections.Generic;
using System.Linq;
using TNRD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neisum.ScriptableEvents
{
    public abstract class ScriptableWithEvents<T> : ScriptableObject
    {
        [SerializeField]
        private List<SerializableInterface<IScriptableEventListener<T>>> listeners = new List<SerializableInterface<IScriptableEventListener<T>>>();

        public void UpdateScriptable(T data)
        {
            RaiseScriptableUpdatedEvent(data);
        }

        private void OnEnable()
        {
            Debug.Log("Enabling");
            ResetVariables();
        }

        private void OnValidate()
        {
            Debug.Log("Validating");
            LoadListeners();
            SceneManager.activeSceneChanged += (scene1, scene2) => { LoadListeners(); ResetVariables(); };
        }

        private void LoadListeners()
        {
            listeners.Clear();
            var dataCallers = FindObjectsOfType<MonoBehaviour>().OfType<IScriptableEventListener<T>>();
            foreach (IScriptableEventListener<T> dataCaller in dataCallers)
            {
                SerializableInterface<IScriptableEventListener<T>> serializableDataCaller = new SerializableInterface<IScriptableEventListener<T>>();
                serializableDataCaller.Value = dataCaller;
                listeners.Add(serializableDataCaller);
            }
        }

        public void RaiseScriptableUpdatedEvent(T data)
        {
            if (listeners.Count > 0)
            {
                for (int i = 0; i < listeners.Count; i++)
                {
                    listeners[i].Value?.ScriptableResponse(data);
                }
            }
        }

        public virtual void ResetVariables() { }
    }
}