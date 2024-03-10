using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Neisum.ScriptableEvents
{
    /// <summary>
    /// Listener from an ScriptableEvent
    /// </summary>
    /// <typeparam name="T">Payload typeOf data</typeparam>
    /// <typeparam name="TGameEvent">ScriptableEvent</typeparam>
    /// <typeparam name="TUnityEvent">UnityEvent<Payload typeOf data></typeparam>
    public abstract class ScriptableListener<T, TGameEvent, TUnityEvent> : MonoBehaviour, IScriptableEventListener<T> where TGameEvent : BaseEvent<T> where TUnityEvent : UnityEvent<T>
    {
        [SerializeField] TGameEvent scriptableEvent;
        [SerializeField] TUnityEvent response;

        private void OnEnable()
        {
            scriptableEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            scriptableEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(T data)
        {
            response.Invoke(data);
        }
    }

    public interface IScriptableEventListener<T>
    {
        public void OnEventRaised(T data);
    }
}