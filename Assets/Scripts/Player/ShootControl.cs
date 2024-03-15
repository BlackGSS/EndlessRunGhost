using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using Neisum.ScriptableEvents;

public class ShootControl : MonoBehaviour
{
    [SerializeField] PlayerDataUpdater playerDataUpdater;
    [SerializeField] OnShootEvent onShootEvent;
    [SerializeField] float fireRate = 1f;
    private float currentRate = 0;

    IEnumerator<float> shootCoroutine;

    void Start()
    {
        currentRate = fireRate;
    }

    public void TryToFire()
    {
        if (currentRate >= fireRate)
        {
            Shoot();
            playerDataUpdater.data.ammoAmount--;
            playerDataUpdater.Notify();
        }
        else
        {
            if (shootCoroutine == null)
                shootCoroutine = ShootDelay();
        }
    }

    IEnumerator<float> ShootDelay()
    {
        yield return Timing.WaitForSeconds(fireRate);
        shootCoroutine = null;
    }

    private void Shoot()
    {
        onShootEvent.Raise(transform);
    }
}
