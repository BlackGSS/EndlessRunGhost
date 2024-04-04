using System.Collections.Generic;
using Neisum.ScriptableEvents;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
	[SerializeField] TilesConfig tilesConfig;
	[SerializeField] ChunkEnablingEvent chunkEnableEvent;
	[SerializeField] ChunkDisablingEvent chunkDisableEvent;
	[SerializeField] GameObject initialTilePrefab;
	[SerializeField] float _initialDelay = 6;
	[SerializeField] float playerSafeZone = 17f;
	[SerializeField] Transform playerTransform;
	
	private float countToDelete = 0;
    private float spawnZ = 0.0f;
	private float safeZone;
	private List<Chunk> _savedTiles;

	//TODO: This should take the Scriptable variable from SessionData
	public static Difficulties currentDificultChunk = Difficulties.EASY;

	void Start()
	{
		_savedTiles = new List<Chunk>();
		safeZone = tilesConfig.amountInitialTiles * tilesConfig.tileLength + playerSafeZone;
		//Sin obstaculos las primeras
		for (int i = 0; i < tilesConfig.amountTiles; i++)
		{
			if (i < tilesConfig.amountInitialTiles)
				SpawnInitialTiles();
			else
				SpawnTiles();
		}
	}

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

	private void SpawnInitialTiles()
	{
		GameObject go;

		go = Instantiate(initialTilePrefab);
		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tilesConfig.tileLength;
	}

	private void SpawnTiles()
	{
		Chunk go = PoolSystem.GetChunkFromPool(currentDificultChunk);

		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tilesConfig.tileLength;
		chunkEnableEvent.Raise(go);
		_savedTiles.Add(go);
	}

	private void DeleteTiles()
	{
		PoolSystem.AddChunkToPool(_savedTiles[0]);
		chunkDisableEvent.Raise(_savedTiles[0]);
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
