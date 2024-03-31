using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] SessionDataUpdater sessionData;
    [SerializeField] PowerUpsPool powerUpsPool;

    private float amountChunks;
    private float chunksLeftToSpawn;
    private int lastPowerUp;
    private int samePowerUpTimes = 2;
    private int currentSamePowerUpTimes = 0;

    //TODO: Maybe this would be incremented to a List<PowerUpCollectable>
    private Dictionary<Chunk, PowerUpCollectable> chunkPowerUps = new Dictionary<Chunk, PowerUpCollectable>();

    public void Start()
    {
        amountChunks = sessionData.data.minChunksToPowerUp;
        chunksLeftToSpawn = amountChunks;
    }

    private PowerUpDataPrefab GetRandomPowerUp()
    {
        int randomNum = Random.Range(0, sessionData.data.availablePowerUps.Length);
        if (randomNum == lastPowerUp)
        {
            if (sessionData.data.availablePowerUps.Length > 1)
            {
                if (currentSamePowerUpTimes >= samePowerUpTimes)
                {
                    currentSamePowerUpTimes = 0;
                    if (randomNum + 1 > sessionData.data.availablePowerUps.Length - 1)
                        randomNum--;
                    else
                        randomNum++;
                }
                else
                {
                    currentSamePowerUpTimes++;
                }
            }
        }

        lastPowerUp = randomNum;
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
        return powerUpsPool.SpawnElement(powerUpCollectableData.powerUpData.Value, powerUpCollectableData.prefab, parentPosition);
    }

    public void RemovePowerUp(Chunk chunk)
    {
        if (chunkPowerUps.Count > 0)
        {
            if (chunkPowerUps.ContainsKey(chunk))
            {
                powerUpsPool.DisableElement(chunkPowerUps[chunk]);
                chunkPowerUps.Remove(chunk);
            }
        }
    }
}