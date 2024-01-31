using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;

	[SerializeField]
	private PlayerControl player;

	[SerializeField]
	private GameObject _pauseMenu;

	// Use this for initialization
	void Awake()
	{
		_pauseMenu.SetActive(false);
		//_timeToPower = 0;
		player.transform.position = transform.position;
		player.transform.rotation = Quaternion.Euler(Vector3.zero);
		// TilesManager.instance.SetPlayer()
	}

	public void Pause()
	{
		if (!_pauseMenu.activeSelf)
		{
			_pauseMenu.SetActive(true);
			Time.timeScale = 0;
			// isPaused = true;
		}
		else
		{
			_pauseMenu.SetActive(false);
			Time.timeScale = 1;
			// isPaused = false;
		}
	}

	public void Resume()
	{
		_pauseMenu.SetActive(false);
		// isPaused = false;
		Time.timeScale = 1;
	}

	public void ReturnMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
