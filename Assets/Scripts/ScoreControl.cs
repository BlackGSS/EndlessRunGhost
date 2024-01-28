using UnityEngine;
using TMPro;
using Neisum.ScriptableEvents;
using System;
using System.Linq;

public class ScoreControl : MonoBehaviour, IScriptableEventListener<SessionData>
{
	[SerializeField] private ScoreUI scoreUI;
	[SerializeField] private SessionData sessionData;
	[SerializeField] private DifficultySettings difficultySettings;
	private float currentScore;
	private int difficultLevel;

	private void Start()
	{
		scoreUI.SetHighscore(((int)PlayerPrefs.GetFloat("Highscore")).ToString());
	}

	// Update is called once per frame
	void Update()
	{
		//TODO: Try with just check if Time.scale is > 0
		if (!sessionData.playerAlive || Time.timeScale <= 0)
			return;

		if (currentScore >= difficultySettings.scoreToNextLevel)
			LevelUp();

		currentScore += Time.deltaTime * difficultLevel;
		scoreUI.SetCurrentScore(((int)currentScore).ToString());
		sessionData.currentScore = (int)currentScore;
	}

	void LevelUp()
	{
		if (difficultLevel == difficultySettings.maxDifficultLevel)
			return;

		difficultySettings.scoreToNextLevel *= 2;
		difficultLevel++;

		ChangeDifficulty(difficultLevel);
	}

	public void OnDeath()
	{
		if (PlayerPrefs.GetFloat("Highscore") < currentScore)
			PlayerPrefs.SetFloat("Highscore", currentScore);
	}

	private void ChangeDifficulty(int newDifficult)
	{
		DifficultiesRange difficultyRange = difficultySettings.difficulties.Where(x => x.minDificultyLevel >= newDifficult && x.maxDificultyLevel <= newDifficult).First();
		sessionData.difficulty = difficultyRange.difficulty;
		sessionData.currentDifficultLevel = difficultLevel;
		sessionData.UpdateScriptable();
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
		{
			OnDeath();
		}
	}
}
