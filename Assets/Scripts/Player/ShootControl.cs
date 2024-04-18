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

    void Update()
    {
#if !PLATFORM_ANDROID || UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
            TryToFire();
#endif
    }

    public void TryToFire()
    {
        if (currentRate >= fireRate)
        {
            if (playerDataUpdater.data.ammoAmount > 0)
            {
                Shoot();
                playerDataUpdater.data.ammoAmount--;
                playerDataUpdater.Notify();
            }
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
        SoundSystem.PlaySound(audioClip, 0.2f);
        onShootEvent.Raise(transform);
    }
}
