using UnityEngine.UI;
using TMPro;
using Neisum.ScriptableUpdaters;
using UnityEngine;

public class DeathMenu : CanvasGroupView, IScriptableUpdaterListener<SessionData>
{
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	public CanvasGroup newHighScoreImage;

	protected override void Init()
	{
		base.Init();
		ShowNewMessage(false);
	}

	private void UpdateScore(float score)
	{
		scoreText.text = ((int)score).ToString();
	}

	private void UpdateHighScore(float highScore)
	{
		highScoreText.text = ((int)highScore).ToString();
	}

	private void ShowNewMessage(bool isNewHighScore)
	{
		newHighScoreImage.alpha = isNewHighScore ? 1 : 0;
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
		{
			FadeAnimTo(1);
			//TODO: Send also the diffultLevel to show in which level player died
			UpdateScore(data.currentScore);

			float currentHighScore = PlayerPrefs.GetInt("Highscore");
			if (currentHighScore < data.currentScore)
			{
				PlayerPrefs.SetInt("Highscore", data.currentScore);
				currentHighScore = data.currentScore;
			}

			ShowNewMessage(currentHighScore <= data.currentScore);
			UpdateHighScore(currentHighScore);

		}
	}
}