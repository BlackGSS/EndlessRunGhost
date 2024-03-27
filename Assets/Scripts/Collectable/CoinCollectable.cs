using DG.Tweening;
using UnityEngine;

public class CoinCollectable : ItemSpawnable<CoinData>
{
    [SerializeField] AudioClip clip;
    [SerializeField] SessionDataUpdater sessionDataUpdater;

    void OnTriggerEnter()
    {
        SoundSystem.PlaySound(clip);
        sessionDataUpdater.data.currentMoneyCollected += data.coinAmount;
        gameObject.SetActive(false);
    }
}
