using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableUpdaters;
using UnityEngine;

public class PlayerSessionListener : MonoBehaviour, IScriptableEventListener<SessionData>
{
    [SerializeField] PlayerDataUpdater playerDataUpdater;

    public void ScriptableResponse(SessionData data)
    {
        playerDataUpdater.data.speed += data.currentDifficultLevel;
    }
}