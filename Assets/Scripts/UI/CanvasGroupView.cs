using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CanvasGroupView : MonoBehaviour
{
    [SerializeField] bool startOn = false;
    [SerializeField] protected float fadeTime;
    [SerializeField] protected CanvasGroup canvasGroup;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        ShowTo(startOn ? 1 : 0);
    }

    protected void EnableCanvasInteraction(bool on)
    {
        canvasGroup.blocksRaycasts = on;
        canvasGroup.interactable = on;
    }

    protected void ShowTo(int fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroup.alpha = fadeValue;
    }

    protected void ShowAnimTo(int fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroup.DOFade(fadeValue, fadeTime);
    }
}
