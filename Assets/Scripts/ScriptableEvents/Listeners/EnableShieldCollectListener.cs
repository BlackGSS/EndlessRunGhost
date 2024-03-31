using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Neisum.ScriptableEvents;
using UnityEngine;
using UnityEngine.Events;

public class EnableShieldCollectListener : ScriptableListener<bool, PowerUpCollectEvent, UnityEvent<bool>>
{
    [SerializeField] ShieldPowerUpData shieldData;
    [SerializeField] MeshRenderer shieldMesh;

    protected override void OnEnable()
    {
        base.OnEnable();
        ActivateShield(false);
    }

    public void ActivateShield(bool activate)
    {
        shieldMesh.enabled = activate;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(shieldMesh.material.DOFloat(activate ? 1 : 0, "_Fill", 0f));
        sequence.Append(shieldMesh.material.DOFloat(activate ? 0 : 1, "_Fill", activate ? shieldData.duration * 2 : 0));
    }
}
