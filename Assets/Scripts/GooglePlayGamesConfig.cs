using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayGamesConfig : MonoBehaviour
{
    public CanvasGroupView loadingCanvas;
    public CanvasGroupView mainMenuCanvas;
    private bool initialized = false;

    public void Start()
    {
        loadingCanvas.Show();
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
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

        if (!initialized)
        {
            ShowButtons();
        }
    }

    private void ShowButtons()
    {
        mainMenuCanvas.Show();
        loadingCanvas.Hide();
    }
}