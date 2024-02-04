using System;
using System.Collections.Generic;
using System.Linq;
using TNRD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neisum.ScriptableUpdaters
{
    public abstract class ScriptableUpdater<T> : ScriptableObject where T : InstantiableScriptable
    {
        [SerializeField] private T templateData;
        public T data;

        [SerializeField] List<SerializableInterface<IScriptableUpdaterListener<T>>> listeners = new List<SerializableInterface<IScriptableUpdaterListener<T>>>();

        public void UpdateScriptable()
        {
            RaiseScriptableUpdatedEvent(data);
        }

        public void OnEnable()
        {
            ResetVariables();
        }

        public void Initialize()
        {
            ResetVariables();
        }

        private void OnValidate()
        {
            LoadListeners();
            SceneManager.activeSceneChanged += (scene1, scene2) => { LoadListeners(); };
        }

        private void LoadListeners()
        {
            listeners.Clear();
            var dataCallers = FindObjectsOfType<MonoBehaviour>().OfType<IScriptableUpdaterListener<T>>();
            foreach (IScriptableUpdaterListener<T> dataCaller in dataCallers)
            {
                SerializableInterface<IScriptableUpdaterListener<T>> serializableDataCaller = new SerializableInterface<IScriptableUpdaterListener<T>>();
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

        public virtual void ResetVariables()
        {
            data = (T)templateData.GetInstance();
        }
    }
}