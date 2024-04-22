using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiableScriptable : ScriptableObject
{
    public InstantiableScriptable GetInstance()
    {
        return Instantiate(this);
    }
}
