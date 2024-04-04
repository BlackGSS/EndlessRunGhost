using System.Collections.Generic;
using MEC;
using UnityEngine;

public class Bullet : ItemSpawnable<BulletConfig>
{
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    [SerializeField] GameObject hitParticle;
    CoroutineHandle coroutineHandle;
    RaycastHit hitInfo;

    float speed = 2;
    private void OnEnable()
    {
        coroutineHandle = Timing.RunCoroutine(CountBulletAliveTime(data.aliveTime));
        speed = data.speed;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        if (Physics.Raycast(transform.position, Vector3.forward, out hitInfo, 1.5f, obstacleLayer))
        {
            if (hitInfo.collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.ApplyDamage(data.damage);
                speed = 0;
                hitParticle.SetActive(true);
                Timing.RunCoroutine(CountBulletAliveTime(1f));
            }
        }
    }

    IEnumerator<float> CountBulletAliveTime(float timeOut)
    {
        yield return Timing.WaitForSeconds(timeOut);
        Disable();
    }

    public override void Disable()
    {
        Timing.KillCoroutines(coroutineHandle);
        hitParticle.SetActive(false);
        base.Disable();
    }
}