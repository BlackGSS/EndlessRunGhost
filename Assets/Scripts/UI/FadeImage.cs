using UnityEngine;
using DG.Tweening;
using System;

public class FadeImage : CanvasGroupView
{
    [SerializeField] int fadeOffset;

    protected override void Init()
    {
        base.Init();
        FadeTo(0);
    }

    public void FadeTo(int fadeValue = 0, Action callback = null)
    {
        FadeSequence(fadeValue, callback);
    }

    private void FadeSequence(int fadeValue, Action callback = null)
    {
        Sequence fade = DOTween.Sequence();
        fade.Append(canvasGroup.DOFade(fadeValue, fadeOffset));
        fade.AppendCallback(() => EnableCanvasInteraction(fadeValue > 0 ? true : false));
        fade.OnComplete(() => callback?.Invoke());
    }
}