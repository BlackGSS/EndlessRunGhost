using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neisum.ScriptableUpdaters;
using DG.Tweening;

public class DeselectButton : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] CanvasGroup button;
    
    public void ScriptableResponse(PlayerData data)
    {
        button.DOFade(data.cosmeticsSelected.Count > 0 ? 1 : 0, 0.2f);
    }
}
