using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] bool showInstructionsOnlyFirstTime;
    [SerializeField] Modal initPowerUps;

    public void ShowRules()
    {
        if (showInstructionsOnlyFirstTime == false)
            FadeImage.Instance.Show(() => initPowerUps.ShowWithAction(GoToGame));
        else
            FadeImage.Instance.Show(() => CheckToShowInstructions());
    }

    private void CheckToShowInstructions()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
            initPowerUps.ShowWithAction(GoToGame);
        else
            GoToGame();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToCosmetic()
    {
        SceneManager.LoadScene("Store");
    }
}
