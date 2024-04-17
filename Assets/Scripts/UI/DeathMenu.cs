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
			FadeImage.Instance.FadeAnimTo(0.8f);
			FadeAnimTo(1);
			//TODO: Send also the diffultLevel to show in which level player died
			UpdateScore(data.currentScore);
			ShowNewMessage(playerDataUpdater.data.highScore <= data.currentScore);

			if (playerDataUpdater.data.highScore < data.currentScore)
				playerDataUpdater.data.highScore = data.currentScore;

			UpdateHighScore(playerDataUpdater.data.highScore);

			totalCoinsText.text = playerDataUpdater.data.money.ToString();
			coinsCollectedText.text = $"+{data.currentMoneyCollected}";
			if (data.currentMoneyCollected > 0)
				Timing.RunCoroutine(AnimateCoinText(data.currentMoneyCollected, playerDataUpdater.data.money).CancelWith(gameObject));

			playerDataUpdater.data.money += data.currentMoneyCollected;
		}
	}

	IEnumerator<float> AnimateCoinText(int currentMoneyCollected, int playerMoney)
	{
		int initialSpeedCount = 5;
		yield return Timing.WaitForSeconds(0.5f);
		while (currentMoneyCollected != 0)
		{
			initialSpeedCount--;
			currentMoneyCollected--;
			totalCoinsText.text = (++playerMoney).ToString();
			totalCoinsText.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), initialSpeedCount > 0 ? 0.15f : 0.03f, 3, 0.3f);
			yield return Timing.WaitForSeconds(initialSpeedCount > 0 ? 0.17f : 0.05f);
		}
		yield return 0;
	}
}