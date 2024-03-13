using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class Bullet : ItemSpawnable<BulletConfig>
{
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    CoroutineHandle coroutineHandle;
    RaycastHit hitInfo;
    private void OnEnable()
    {
        coroutineHandle = Timing.RunCoroutine(CountBulletAliveTime().CancelWith(gameObject));
    }

    void Update()
    {
        transform.Translate(data.speed * sessionDataUpdater.data.currentDifficultLevel * Time.deltaTime * Vector3.forward);
        if (Physics.Raycast(transform.position, Vector3.forward, out hitInfo, 1f, obstacleLayer))
        {
            if (hitInfo.collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.ApplyDamage(data.damage);
                Disable();
            }
        }
    }

    IEnumerator<float> CountBulletAliveTime()
    {
        yield return Timing.WaitForSeconds(data.aliveTime);
        Disable();
    }
}