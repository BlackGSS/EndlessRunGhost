using UnityEngine;
using DG.Tweening;
using System;

public class FadeImage : MonoBehaviour
{
    [SerializeField] int fadeOffset;
    [SerializeField] CanvasGroup canvasGroupFade;

    private void Start()
    {
        ResetFadeTo(1);
        FadeTo(0);
    }

    public void FadeTo(int fadeValue = 0, Action callback = null)
    {
        FadeSequence(fadeValue, callback);
    }

    private void FadeSequence(int fadeValue, Action callback = null)
    {
        Sequence fade = DOTween.Sequence();
        fade.Append(canvasGroupFade.DOFade(fadeValue, fadeOffset));
        fade.AppendCallback(() => EnableCanvasInteraction(fadeValue > 0 ? true : false));
        fade.OnComplete(() => callback?.Invoke());
    }

    private void EnableCanvasInteraction(bool on)
    {
        canvasGroupFade.blocksRaycasts = on;
        canvasGroupFade.interactable = on;
    }

    private void ResetFadeTo(int fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroupFade.alpha = fadeValue;
    }
}