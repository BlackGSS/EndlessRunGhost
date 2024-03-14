using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableEvents;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    [SerializeField] BulletConfig bulletConfig;
    [SerializeField] BulletPool bulletPool;
    [SerializeField] Bullet prefab;

    public void SpawnBullet(Transform playerTransform)
    {
        Bullet newBullet = bulletPool.SpawnElement(bulletConfig, prefab, playerTransform);
        // newBullet.transform.position = playerTransform.position;
    }
}
