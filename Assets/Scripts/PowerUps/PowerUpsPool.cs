using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour
{
    [SerializeField] List<PowerUpCollectable> currentPowerUpCollectable;

    //TODO: Pass parent, the parent will be a point in the current chunk
    public void SpawnPowerUp(IPowerUp powerUpData, PowerUpCollectable prefab, Transform parent)
    {
        if (currentPowerUpCollectable.Count > 0)
        {
            for (int i = 0; i < currentPowerUpCollectable.Count; i++)
            {
                if (!currentPowerUpCollectable[i].gameObject.activeSelf)
                {
                    currentPowerUpCollectable[i].Initialize(powerUpData);
                    break;
                }
            }
        }
        else
        {
            AddPowerUp(powerUpData, prefab);
        }
    }

    public void AddPowerUp(IPowerUp data, PowerUpCollectable prefab)
    {
        PowerUpCollectable newPowerUp = Instantiate(prefab);
        newPowerUp.Initialize(data);
    }
}