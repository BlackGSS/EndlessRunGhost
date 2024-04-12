using System;
using DG.Tweening;
using UnityEngine;

public class CanvasGroupView : MonoBehaviour
{
    [SerializeField] bool startOn = false;
    [SerializeField] protected float fadeTime;
    [SerializeField] protected CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        FadeTo(startOn ? 1 : 0);
    }

    protected void EnableCanvasInteraction(bool on)
    {
        canvasGroup.blocksRaycasts = on;
        canvasGroup.interactable = on;
    }

    public void FadeTo(float fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroup.alpha = fadeValue;
    }

    public void FadeAnimTo(float fadeValue, Action callback = null)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(fadeValue, fadeTime));
        sequence.OnComplete(() => callback?.Invoke());
    }

    public void Show(Action callback = null)
    {
        FadeAnimTo(1, callback);
    }

    protected void Hide()
    {
        FadeAnimTo(0);
    }
}
