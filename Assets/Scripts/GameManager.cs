using System.Collections.Generic;
using MEC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _pauseMenu;

	[SerializeField]
	private CanvasGroupView handHelpView;

	[SerializeField]
	private int timeToShowHandAnim = 5;

	[SerializeField]
	private PlayerFactory playerFactory;

	[SerializeField] SessionDataUpdater sessionDataUpdater;

	// Use this for initialization
	void Awake()
	{
		_pauseMenu.SetActive(false);
		playerFactory.SpawnSessionPlayer();
	}

	void Start()
	{
		FadeImage.Instance.FadeAnimTo(0);
		Debug.Log(PlayerPrefs.GetInt("FirstTime"));
		if (PlayerPrefs.GetInt("FirstTime") != 1)
		{
			handHelpView.ShowFor(timeToShowHandAnim);
			PlayerPrefs.SetInt("FirstTime", 1);
		}
	}

	public void Pause()
	{
		if (!_pauseMenu.activeSelf)
		{
			_pauseMenu.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			_pauseMenu.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		_pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}

	public void ReturnMenu()
	{
		Time.timeScale = 1;
		GlobalParticleSystem.Clear();
		SceneManager.LoadScene("MainMenu");
	}

	public void Restart()
	{
		GlobalParticleSystem.Clear();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
