using Neisum.ScriptableEvents;
using Neisum.ScriptableUpdaters;
using UnityEngine;
using UnityEngine.Events;

public class ChunkShieldCollectListener : ScriptableListener<bool, PowerUpCollectEvent, UnityEvent<bool>>
{
    [SerializeField] PlayerDataUpdater playerDataUpdater;
    [SerializeField] GameObject obstacleParent;
    private Collider[] obstacleColliders;

    private void Awake()
    {
        obstacleColliders = obstacleParent.GetComponentsInChildren<Collider>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ActivateCollision(playerDataUpdater.data.isInvincible);
    }

    public void ActivateCollision(bool active)
    {
        if (obstacleColliders.Length > 0)
            if (!obstacleColliders[0].isTrigger == active)
                for (int i = 0; i < obstacleColliders.Length; i++)
                {
                    obstacleColliders[i].isTrigger = active;
                }
    }
}
