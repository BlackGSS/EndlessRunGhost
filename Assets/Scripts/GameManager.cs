﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;
	public static int playerSelected = 0;

	[SerializeField]
	private PlayerControl player;

	[SerializeField]
	private GameObject _pauseMenu;

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
		player.transform.position = transform.position;
		player.transform.rotation = Quaternion.Euler(Vector3.zero);
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
}