using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableEvents;
using UnityEngine;
using UnityEngine.Events;

public class EnableShieldCollectListener : ScriptableListener<bool, PowerUpCollectEvent, UnityEvent<bool>>
{
    [SerializeField] MeshRenderer shieldMesh;

    protected override void OnEnable()
    {
        base.OnEnable();
        shieldMesh.enabled = false;
    }

    public void ActivateShield(bool activate)
    {
        shieldMesh.enabled = activate;
    }
}
