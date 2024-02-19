using UnityEngine;
using Neisum.ScriptableUpdaters;
using System.Linq;

public class ScoreControl : MonoBehaviour, IScriptableUpdaterListener<SessionData>
{
	[SerializeField] private ScoreUI scoreUI;
	[SerializeField] private SessionDataUpdater sessionData;
	[SerializeField] private DifficultySettings difficultySettings;
	private float currentScore;
	private int difficultLevel;
	private int scoreToNextLevel;

	private void Start()
	{
		scoreUI.SetHighscore(((int)PlayerPrefs.GetFloat("Highscore")).ToString());
		difficultLevel = sessionData.data.currentDifficultLevel;
		scoreToNextLevel = difficultySettings.scoreToFirstLevel;
	}

	void Update()
	{
		if (!sessionData.data.playerAlive || Time.timeScale <= 0)
			return;

		if (currentScore >= scoreToNextLevel)
			LevelUp();

		currentScore += Time.deltaTime * difficultLevel;
		scoreUI.SetCurrentScore(((int)currentScore).ToString());
		sessionData.data.currentScore = (int)currentScore;
	}

	void LevelUp()
	{
		if (difficultLevel == difficultySettings.maxDifficultLevel)
			return;

		scoreToNextLevel *= 2;
		difficultLevel++;

		ChangeDifficulty(difficultLevel);
	}

	private void ChangeDifficulty(int newDifficult)
	{
		DifficultiesRange difficultyRange = difficultySettings.difficulties.Where(x => x.minDificultyLevel <= newDifficult && x.maxDificultyLevel >= newDifficult).First();
		sessionData.data.difficulty = difficultyRange.difficulty;
		sessionData.data.currentDifficultLevel = difficultLevel;
		sessionData.Notify();
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
			OnDeath();
	}

	public void OnDeath()
	{
		if (PlayerPrefs.GetFloat("Highscore") < currentScore)
			PlayerPrefs.SetFloat("Highscore", currentScore);
	}
}
