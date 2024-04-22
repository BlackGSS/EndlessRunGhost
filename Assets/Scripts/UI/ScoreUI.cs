using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image levelImage;

    public void SetCurrentScore(int score)
    {
        scoreText.text = score >= 100 ? score.ToString() : score >= 10 ? $"0{score}" : $"00{score}";
    }

    public void SetLevelText(string level, Sprite difficultySprite)
    {
        levelText.text = level;
        levelImage.sprite = difficultySprite;
    }
}
