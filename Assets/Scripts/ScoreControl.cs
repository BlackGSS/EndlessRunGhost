using UnityEngine;
using TMPro;
using Neisum.ScriptableEvents;
using System;
using System.Linq;

public class ScoreControl : MonoBehaviour, IScriptableEventListener<SessionData>
{
	[SerializeField] private SessionData sessionData;
	private float currentScore;
	private int difficultLevel;
	private int maxDifficultLevel = 15;
	private int scoreToNextLevel = 10;

	private TextMeshProUGUI _scoreText, _highscoreText;

	[SerializeField]
	private DifficultiesRange[] difficulties;

	private void Start()
	{
		_scoreText = GameManager.instance.score;
		_highscoreText = GameManager.instance.highScore;
		_highscoreText.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		//TODO: Try with just check if Time.scale is > 0
		if (!sessionData.playerAlive || Time.timeScale <= 0)
			return;

		if (currentScore >= scoreToNextLevel)
			LevelUp();

		currentScore += Time.deltaTime * difficultLevel;
		_scoreText.text = ((int)currentScore).ToString();
		sessionData.score = (int)currentScore;
	}

	void LevelUp()
	{
		if (difficultLevel == maxDifficultLevel)
			return;

		scoreToNextLevel *= 2;
		difficultLevel++;

		ChangeDifficulty(difficultLevel); 

		// TODO: Wtf, out of here
		GetComponent<PlayerControl>().SetSpeed(difficultLevel);
	}

	public void OnDeath()
	{
		if (PlayerPrefs.GetFloat("Highscore") < currentScore)
			PlayerPrefs.SetFloat("Highscore", currentScore);
	}

	private void ChangeDifficulty(int newDifficult)
	{
		DifficultiesRange difficultyRange = difficulties.Where(x => x.minDificultyLevel >= newDifficult && x.maxDificultyLevel <= newDifficult).First();
		sessionData.difficulty = difficultyRange.difficulty;
		sessionData.UpdateScriptable(sessionData);
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
		{
			OnDeath();
		}
	}
}
