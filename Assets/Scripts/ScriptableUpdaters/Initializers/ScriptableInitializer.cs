using Neisum.ScriptableUpdaters;
using UnityEngine;

public class ScriptableInitializer<T, U> : MonoBehaviour where T : ScriptableUpdater<U> where U: InstantiableScriptable
{
    [SerializeField] protected T value;

    protected virtual void Awake()
    {
        value.Initialize();
    }

    void Start()
    {
        value.Notify();
    }

    protected virtual void OnDestroy()
    {
        value.ResetVariables();
    }
}
