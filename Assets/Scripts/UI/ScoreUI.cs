using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void SetHighscore(string score)
    {
        highScoreText.text = score;
    }

    public void SetCurrentScore(string score)
    {
        scoreText.text = score;
    }
}
