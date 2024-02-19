using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour
{
    [SerializeField] List<PowerUpCollectable> currentPowerUpCollectable;

    //TODO: Pass parent, the parent will be a point in the current chunk
    public PowerUpCollectable SpawnPowerUp(IPowerUp powerUpData, PowerUpCollectable prefab, Transform parentPosition)
    {
        if (currentPowerUpCollectable.Count > 0)
        {
            for (int i = 0; i < currentPowerUpCollectable.Count; i++)
            {
                if (!currentPowerUpCollectable[i].gameObject.activeSelf)
                {
                    currentPowerUpCollectable[i].Initialize(powerUpData);
                    UpdatePosition(currentPowerUpCollectable[i], parentPosition);
                    return currentPowerUpCollectable[i];
                }
            }
            return AddPowerUp(powerUpData, prefab, parentPosition);
        }
        else
        {
            return AddPowerUp(powerUpData, prefab, parentPosition);
        }
    }

    public PowerUpCollectable AddPowerUp(IPowerUp data, PowerUpCollectable prefab, Transform parentPosition)
    {
        PowerUpCollectable newPowerUp = Instantiate(prefab, transform);
        UpdatePosition(newPowerUp, parentPosition);
        newPowerUp.Initialize(data);
        currentPowerUpCollectable.Add(newPowerUp);
        return newPowerUp;
    }

    private void UpdatePosition(PowerUpCollectable powerUp, Transform newPos)
    {
        powerUp.transform.position = newPos.position;
    }

    public void DisablePowerUp(PowerUpCollectable powerUp)
    {
        powerUp.Disable();
    }
}