using System;
using TMPro;
using UnityEngine;

public class Modal : CanvasGroupView
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI acceptButtonText;
    private Action callbackOnAccept;

    public void Show(string title, string buttonText, Action callback = null)
    {
        titleText.text = title;
        acceptButtonText.text = buttonText;
        callbackOnAccept = callback;
        Show();
    }

    public void ShowWithAction(Action callback)
    {
        callbackOnAccept = callback;
        Show();
    }

    public void Confirm()
    {
        if (callbackOnAccept != null)
            callbackOnAccept.Invoke();
        Hide();
    }

    public void Cancel()
    {
        Hide();
    }
}
