using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] SessionDataUpdater sessionData;
    [SerializeField] PowerUpsPool powerUpsPool;
    [SerializeField] float amountChunks = 8;
    [SerializeField] float chunksLeftToSpawn;

    public void Start()
    {
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
                SpawnPowerUp(transform);
                amountChunks = Random.Range(sessionData.data.minChunksToPowerUp, sessionData.data.maxChunksToPowerUp);
                chunksLeftToSpawn = amountChunks;
            }
            else
            {
                chunksLeftToSpawn++;
            }
        }
    }

    private void SpawnPowerUp(Transform parentPosition)
    {
        PowerUpDataPrefab powerUpCollectableData = GetRandomPowerUp();
        powerUpsPool.SpawnPowerUp(powerUpCollectableData.powerUpData.Value, powerUpCollectableData.prefab, parentPosition);
    }
}