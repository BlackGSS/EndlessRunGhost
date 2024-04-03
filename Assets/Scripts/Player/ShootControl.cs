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
    [SerializeField] AudioClip audioClip;
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
        SoundSystem.PlaySound(audioClip, 0.3f);
        onShootEvent.Raise(transform);
    }
}
