using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
	private float score = 0.0f;
	private int difficultLevel = 1;
	private int maxDifficultLevel = 15;
	private int scoreToNextLevel = 10;

	private TextMeshProUGUI _scoreText, _highscoreText;

	public float TotalScore { get { return score; } }
	private DeathMenu _deathMenu;

	private void Start()
	{
		_scoreText = GameManager.instance.score;
		_highscoreText = GameManager.instance.highScore;
		_deathMenu = GameManager.instance.deathMenu;
		_highscoreText.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		//TODO: Try with just check if Time.scale is > 0
		if (GetComponent<PlayerControl>().isDead || GameManager.instance.isPaused)
			return;

		if (score >= scoreToNextLevel)
			LevelUp();

		score += Time.deltaTime * difficultLevel;
		_scoreText.text = ((int)score).ToString();
	}

	void LevelUp()
	{
		if (difficultLevel == maxDifficultLevel)
			return;

		scoreToNextLevel *= 2;
		print(scoreToNextLevel);
		difficultLevel++;

		//TODO: Out of here
		if (difficultLevel <= 3)
		{
			TilesManager.currentDificultChunk = Dificulties.EASY;
		}
		else if (difficultLevel <= 7)
		{
			TilesManager.currentDificultChunk = Dificulties.MEDIUM;
		}
		else
		{
			TilesManager.currentDificultChunk = Dificulties.HARD;
		}

		// TODO: Wtf, out of here
		GetComponent<PlayerControl>().SetSpeed(difficultLevel);
	}

	public void OnDeath()
	{
		if (PlayerPrefs.GetFloat("Highscore") < score)
			PlayerPrefs.SetFloat("Highscore", score);

		// TODO: Wtf, out of here
		_deathMenu.ToggleEndMenu(score);
	}
}
