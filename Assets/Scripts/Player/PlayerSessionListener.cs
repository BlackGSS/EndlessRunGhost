using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableUpdaters;
using UnityEngine;

public class PlayerSessionListener : MonoBehaviour, IScriptableUpdaterListener<SessionData>
{
    [SerializeField] PlayerDataUpdater playerDataUpdater;

    public void ScriptableResponse(SessionData data)
    {
        if (playerDataUpdater.data.baseSpeed + data.currentDifficultLevel != playerDataUpdater.data.speed)
        {
            playerDataUpdater.data.speed = playerDataUpdater.data.baseSpeed + data.currentDifficultLevel;
            playerDataUpdater.Notify();
        }
    }
}