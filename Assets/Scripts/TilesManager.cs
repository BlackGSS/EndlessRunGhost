using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
	[SerializeField] TilesConfig tilesConfig;
	[SerializeField] GameObject _initialPrefabs;
	[SerializeField] float _initialDelay = 6;
	[SerializeField] Transform playerTransform;
	
	private float countToDelete = 0;
    private float spawnZ = 0.0f;
	private float safeZone = 58f;
	
	// TODO: Try to use a Scriptable to store the tiles for perssistence between scenes
	private List<GameObject> _savedTiles;

	public static Difficulties currentDificultChunk = Difficulties.EASY;

	// Use this for initialization
	void Start()
	{
		_savedTiles = new List<GameObject>();
		safeZone = tilesConfig.amountInitialTiles * tilesConfig.tileLength + 12f;
		//Sin obstaculos las primeras
		for (int i = 0; i < tilesConfig.amountTiles; i++)
		{
			if (i < tilesConfig.amountInitialTiles)
				SpawnInitialTiles();
			else
				SpawnTiles();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (countToDelete < _initialDelay)
		{
			countToDelete += Time.deltaTime;
		}
		else
		{
			if (playerTransform.position.z - safeZone > (spawnZ - tilesConfig.amountTiles * tilesConfig.tileLength))
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
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tilesConfig.tileLength;
	}

	/// <summary>
	/// Spawn a Chunk from the Pool System
	/// </summary>
	private void SpawnTiles()
	{
		GameObject go;

		go = PoolSystem.GetChunkFromPool(currentDificultChunk);

		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tilesConfig.tileLength;
		_savedTiles.Add(go);
	}

	private void DeleteTiles()
	{
		PoolSystem.AddChunkToPool(_savedTiles[0]);
		Debug.Log(_savedTiles[0]);
		_savedTiles.RemoveAt(0);
	}

	public void SetPlayerTransform(PlayerControl player)
	{
		playerTransform = player.transform;
	}

	void OnDestroy()
	{
		PoolSystem.ResetChunks();
	}
}
