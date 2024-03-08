using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableEvents;
using UnityEngine;

public class BulletsManager : IScriptableEventListener<OnShootEvent>
{
    [SerializeField] BulletPool bulletPool;

    public void OnEventRaised(OnShootEvent data)
    {
        // Bullet bullet = bulletPool.
    }
}
