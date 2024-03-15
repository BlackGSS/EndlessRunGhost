using UnityEngine;
using System.Linq;

public class ScoreControl : MonoBehaviour
{
	[SerializeField] private ScoreUI scoreUI;
	[SerializeField] private SessionDataUpdater sessionData;
	[SerializeField] private DifficultySettings difficultySettings;
	private float currentScore;
	private int difficultLevel;
	private int scoreToNextLevel;

	private void Start()
	{
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
		scoreUI.SetCurrentScore((int)currentScore);
		sessionData.data.currentScore = (int)currentScore;
	}

	void LevelUp()
	{
		if (difficultLevel == difficultySettings.maxDifficultLevel)
			return;

		scoreToNextLevel *= 2;
		difficultLevel++;

		ChangeDifficulty(difficultLevel);
		scoreUI.SetLevelText(difficultLevel.ToString());
	}

	private void ChangeDifficulty(int newDifficult)
	{
		DifficultiesRange difficultyRange = difficultySettings.difficulties.Where(x => x.minDificultyLevel <= newDifficult && x.maxDificultyLevel >= newDifficult).First();
		sessionData.data.difficulty = difficultyRange.difficulty;
		sessionData.data.currentDifficultLevel = difficultLevel;
		sessionData.Notify();
	}
}
