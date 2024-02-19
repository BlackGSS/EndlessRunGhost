using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] SessionDataUpdater sessionData;
    [SerializeField] PowerUpsPool powerUpsPool;
    [SerializeField] float amountChunks;
    [SerializeField] float chunksLeftToSpawn;

    //TODO: Maybe this would be incremented to a List<PowerUpCollectable>
    private Dictionary<Chunk, PowerUpCollectable> chunkPowerUps = new Dictionary<Chunk, PowerUpCollectable>();

    public void Start()
    {
        amountChunks = sessionData.data.minChunksToPowerUp;
        chunksLeftToSpawn = amountChunks;
    }

    private PowerUpDataPrefab GetRandomPowerUp()
    {
        int randomNum = Random.Range(0, sessionData.data.availablePowerUps.Length - 1);
        return sessionData.data.availablePowerUps[randomNum];
    }

    public void CheckToSpawnPowerUp(Chunk chunk)
    {
        chunksLeftToSpawn--;
        if (chunksLeftToSpawn == 0)
        {
            if (chunk.GetRandomPointTransform(out Transform transform))
            {
                PowerUpCollectable collectable = SpawnPowerUp(transform);
                amountChunks = Random.Range(sessionData.data.minChunksToPowerUp, sessionData.data.maxChunksToPowerUp);
                chunksLeftToSpawn = amountChunks;
                chunkPowerUps.Add(chunk, collectable);
            }
            else
            {
                chunksLeftToSpawn++;
            }
        }
    }

    private PowerUpCollectable SpawnPowerUp(Transform parentPosition)
    {
        PowerUpDataPrefab powerUpCollectableData = GetRandomPowerUp();
        return powerUpsPool.SpawnPowerUp(powerUpCollectableData.powerUpData.Value, powerUpCollectableData.prefab, parentPosition);
    }

    public void RemovePowerUp(Chunk chunk)
    {
        if (chunkPowerUps.Count > 0)
        {
            if (chunkPowerUps.ContainsKey(chunk))
            {
                powerUpsPool.DisablePowerUp(chunkPowerUps[chunk]);
                chunkPowerUps.Remove(chunk);
            }
        }
    }
}