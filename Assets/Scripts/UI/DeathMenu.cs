using UnityEngine.UI;
using TMPro;
using Neisum.ScriptableUpdaters;
using UnityEngine;
using MEC;
using System.Collections.Generic;
using DG.Tweening;

//TODO: Divide in DeathController and DeathView
public class DeathMenu : CanvasGroupView, IScriptableUpdaterListener<SessionData>
{
	[SerializeField] PlayerDataUpdater playerDataUpdater;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI highScoreText;
	[SerializeField] TextMeshProUGUI totalCoinsText;
	[SerializeField] TextMeshProUGUI coinsCollectedText;
	[SerializeField] CanvasGroup newHighScoreImage;
	[SerializeField] AudioClip dieClip;

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
			SoundSystem.PlaySound(dieClip, 1f);
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

			//TODO: BUG, this add money to the temp data, not the template
			playerDataUpdater.data.money += data.currentMoneyCollected;
		}
	}

	IEnumerator<float> AnimateCoinText(int currentMoneyCollected, int playerMoney)
	{
		int initialSpeedCount = 10;
		yield return Timing.WaitForSeconds(0.5f);
		while (currentMoneyCollected != 0)
		{
			initialSpeedCount--;
			currentMoneyCollected--;
			totalCoinsText.text = (++playerMoney).ToString();
			totalCoinsText.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), initialSpeedCount > 0 ? 0.13f : 0.08f, 3, 0.3f);
			yield return Timing.WaitForSeconds(initialSpeedCount > 0 ? 0.15f : 0.1f);
		}
		yield return 0;
	}
}