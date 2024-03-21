using UnityEngine.UI;
using TMPro;
using Neisum.ScriptableUpdaters;
using UnityEngine;
using MEC;
using System.Collections.Generic;
using DG.Tweening;

public class DeathMenu : CanvasGroupView, IScriptableUpdaterListener<SessionData>
{
	[SerializeField] PlayerDataUpdater playerDataUpdater;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI highScoreText;
	[SerializeField] TextMeshProUGUI totalCoinsText;
	[SerializeField] TextMeshProUGUI coinsCollectedText;
	[SerializeField] CanvasGroup newHighScoreImage;

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
			FadeImage.Instance.FadeAnimTo(0.5f);
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

			totalCoinsText.text = playerDataUpdater.data.money.ToString();
			coinsCollectedText.text = $"+{data.currentMoneyCollected}";
			if (data.currentMoneyCollected > 0)
				Timing.RunCoroutine(AnimateCoinText(data.currentMoneyCollected, playerDataUpdater.data.money));
			
			playerDataUpdater.data.money += data.currentMoneyCollected;
		}
	}

	IEnumerator<float> AnimateCoinText(int currentMoneyCollected, int playerMoney)
	{
		yield return Timing.WaitForSeconds(1f);
		while (currentMoneyCollected != 0)
		{
			totalCoinsText.text = (++playerMoney).ToString();
			totalCoinsText.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.13f, 3, 0.3f);
			currentMoneyCollected--;
			yield return Timing.WaitForSeconds(0.15f);
		}
		Debug.Log("Done");
		yield return 0;
	}
}