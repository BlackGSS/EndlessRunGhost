using UnityEngine;

public class LeaderBoardModal : Modal
{
    public void ShowModal()
    {
        if (PlayerPrefs.GetInt("LeaderBoard") == 0)
            ShowWithAction(ShowLeaderBoard);
        else
            ShowLeaderBoard();
    }

    private void ShowLeaderBoard()
    {
        if (PlayerPrefs.GetInt("LeaderBoard") == 0)
            PlayerPrefs.SetInt("LeaderBoard", 1);

        Social.ShowLeaderboardUI();
    }
}