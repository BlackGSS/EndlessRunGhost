using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScriptableCaller<T>
{
    event Action<T> OnValueChanged;
}
