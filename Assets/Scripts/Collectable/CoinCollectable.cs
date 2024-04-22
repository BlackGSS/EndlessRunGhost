using UnityEngine;

public class CoinCollectable : ItemSpawnable<CoinData>
{
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    [SerializeField] AudioClip clip;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] Collider col;

    void OnEnable()
    {
        col.enabled = true;
        mesh.enabled = true;
    }

    void OnTriggerEnter()
    {
        SoundSystem.PlaySound(clip, 0.6f);
        sessionDataUpdater.data.currentMoneyCollected += data.coinAmount;
        sessionDataUpdater.Notify();
        col.enabled = false;
        mesh.enabled = false;
    }
}
