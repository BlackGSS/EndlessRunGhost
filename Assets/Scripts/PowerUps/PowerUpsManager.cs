using System.Collections.Generic;
using MEC;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] PowerUpCollectableData[] collectableDataPrefabs;

    [SerializeField] PowerUpsPool powerUpsPool;
    [SerializeField] float powerUpDelayTime = 12f;

    public void Start()
    {
        Timing.RunCoroutine(SpawnPowerUp());
    }

    IEnumerator<float> SpawnPowerUp()
    {
        yield return Timing.WaitForSeconds(powerUpDelayTime);
        PowerUpCollectableData powerUpCollectableData = GetRandomPowerUp();
        powerUpsPool.SpawnPowerUp(powerUpCollectableData.powerUpData, powerUpCollectableData.prefab, null);
    }

    private PowerUpCollectableData GetRandomPowerUp()
    {
        int randomNum = Random.Range(0, collectableDataPrefabs.Length - 1);
        return collectableDataPrefabs[randomNum];
    }
}

public class PowerUpCollectableData
{
    public IPowerUp powerUpData;
    public PowerUpCollectable prefab;
}