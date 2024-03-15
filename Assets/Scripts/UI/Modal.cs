using System;

public class Modal : CanvasGroupView
{
    private Action callbackOnAccept;

    public void Show(Action callback)
    {
        callbackOnAccept = callback;
        Show();
    }

    public void Confirm()
    {
        callbackOnAccept.Invoke();
        Hide();
    }

    public void Cancel()
    {
        Hide();
    }
}
