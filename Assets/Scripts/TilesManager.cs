using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _initialPrefabs;
	[SerializeField]
	private Transform _playerTransform;
	private List<GameObject> _savedTiles;

	private float _spawnZ = 0.0f;
	private float _tileLength = 20.5f;
	private float _safeZone = 58f;
	private int _amountTiles = 8;
	private int _amountInitialTiles = 2;
	private int _lastPrefabIndex = 0;

	private float _countToDelete = 0;
	[SerializeField]
	private float _initialDelay = 6;

	public static Difficulties currentDificultChunk = Difficulties.EASY;

	private static TilesManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start()
	{
		DontDestroyOnLoad(this);
		_savedTiles = new List<GameObject>();

		_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		//Sin obstaculos las primeras
		for (int i = 0; i < _amountTiles; i++)
		{
			if (i < _amountInitialTiles)
				SpawnInitialTiles();
			else
				SpawnTiles();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (_countToDelete < _initialDelay)
		{
			_countToDelete += Time.deltaTime;
		}
		else
		{
			if (_playerTransform.position.z - _safeZone > (_spawnZ - _amountTiles * _tileLength))
			{
				SpawnTiles();
				DeleteTiles();
			}
		}
	}

	/// <summary>
	/// Spawn the first and the second Chunk;
	/// </summary>
	private void SpawnInitialTiles()
	{
		GameObject go;

		go = Instantiate(_initialPrefabs);
		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * _spawnZ;
		_spawnZ += _tileLength;
	}

	/// <summary>
	/// Spawn a Chunk from the Pool System
	/// </summary>
	private void SpawnTiles()
	{
		GameObject go;

		go = PoolSystem.GetChunkFromPool(currentDificultChunk);

		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * _spawnZ;
		_spawnZ += _tileLength;
		_savedTiles.Add(go);
	}

	private void DeleteTiles()
	{
		PoolSystem.AddChunkToPool(_savedTiles[0]);
		Debug.Log(_savedTiles[0]);
		_savedTiles.RemoveAt(0);
	}
}
