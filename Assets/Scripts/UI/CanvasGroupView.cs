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
        FadeTo(startOn ? 1 : 0);
    }

    protected void EnableCanvasInteraction(bool on)
    {
        canvasGroup.blocksRaycasts = on;
        canvasGroup.interactable = on;
    }

    public void FadeTo(int fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroup.alpha = fadeValue;
    }

    public void FadeAnimTo(int fadeValue)
    {
        EnableCanvasInteraction(fadeValue > 0 ? true : false);
        canvasGroup.DOFade(fadeValue, fadeTime);
    }
}
