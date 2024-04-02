using UnityEngine;

public class CoinCollectable : ItemSpawnable<CoinData>
{
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    [SerializeField] AudioClip clip;
    // [SerializeField] ParticleSystem brilliPrefab;
    // [SerializeField] Transform modelTransform;

    void OnTriggerEnter()
    {
        SoundSystem.PlaySound(clip);
        // GlobalParticleSystem.Play(brilliPrefab, modelTransform);
        sessionDataUpdater.data.currentMoneyCollected += data.coinAmount;
        gameObject.SetActive(false);
    }
}
