using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;
	public static int playerSelected = 0;

	//public GameObject powerUp;
	//private float _timeToPower;

	// [SerializeField]
	// private Image _fadeIn;

	public TextMeshProUGUI score, highScore;
	public DeathMenu deathMenu;
	public ScoreControl scoreControl;

	[SerializeField]
	private GameObject _pauseMenu;

	public bool isPaused;

	public static GameManager instance;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		_pauseMenu.SetActive(false);
		//_timeToPower = 0;
		PlayerControl player = Instantiate(players[playerSelected], transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<PlayerControl>();
		player.OnDeath += scoreControl.OnDeath;
		player.OnDeath += () => deathMenu.ToggleEndMenu(scoreControl.TotalScore);
	}

	public void Pause()
	{
		if (!_pauseMenu.activeSelf)
		{
			_pauseMenu.SetActive(true);
			isPaused = true;
		}
		else
		{
			_pauseMenu.SetActive(false);
			isPaused = false;
		}
	}

	public void Resume()
	{
		if (isPaused)
			_pauseMenu.SetActive(false);
			isPaused = false;
	}
}
