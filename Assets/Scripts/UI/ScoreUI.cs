using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;

    public void SetCurrentScore(int score)
    {
        scoreText.text = score >= 10 ? score.ToString() : $"0{score}";
    }

    public void SetLevelText(string level)
    {
        levelText.text = level;
    }
}
