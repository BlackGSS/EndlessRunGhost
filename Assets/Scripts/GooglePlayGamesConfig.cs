using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections.Generic;

public class GooglePlayGamesConfig : MonoBehaviour
{
    public CanvasGroupView loadingCanvas;
    public CanvasGroupView mainMenuCanvas;

    public void Start()
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Debug.Log("Not already authenticated");
            loadingCanvas.Show();
            PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        }
        else
        {
            Debug.Log("Is already authenticated");
            ShowButtons();
        }
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            Debug.Log("Signed player with Google Play");
        }
        else
        {
            Debug.Log("Not Auth");
            // Disable your integration with Play Games Services or show a login button
            // to ask users to sign-in. Clicking it should call
            // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
        }

        MEC.Timing.RunCoroutine(WaitToShowButtons());
    }

    IEnumerator<float> WaitToShowButtons()
    {
        yield return MEC.Timing.WaitForSeconds(0.5f);
        ShowButtons();
    }

    private void ShowButtons()
    {
        loadingCanvas.Hide();
        mainMenuCanvas.Show();
    }
}