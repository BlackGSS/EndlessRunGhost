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
        scoreText.text = score >= 10 ? score.ToString() : $"0{score}";
    }

    public void SetLevelText(string level, Sprite difficultySprite)
    {
        levelText.text = level;
        levelImage.sprite = difficultySprite;
    }
}
