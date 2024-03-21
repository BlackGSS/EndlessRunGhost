using UnityEngine;
using DG.Tweening;
using System;

public class FadeImage : CanvasGroupView
{
    [SerializeField] int fadeOffset;

    public static FadeImage Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    protected override void Init()
    {
        base.Init();
        FadeAnimTo(0);
    }
}