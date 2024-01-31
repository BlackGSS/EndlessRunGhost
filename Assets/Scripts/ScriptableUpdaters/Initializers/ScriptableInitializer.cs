using Neisum.ScriptableUpdaters;
using UnityEngine;

public class ScriptableInitializer<T, U> : MonoBehaviour where T : ScriptableUpdater<U> where U: InstantiableScriptable
{
    [SerializeField] T value;

    void Awake()
    {
        value.Initialize();
    }

    void OnDestroy()
    {
        value.ResetVariables();
    }
}
