using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class InstantiableScriptable : ScriptableObject
{
    public InstantiableScriptable GetInstance()
    {
        return Instantiate(this);
    }
}
