using System.Collections.Generic;
using MEC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;

	[SerializeField]
	private GameObject _pauseMenu;

	[SerializeField]
	private Modal initialPowerUpView;

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
		initialPowerUpView.Show();
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

	// IEnumerator<float> ShowPowerUpModal()
	// {
	// }
}
