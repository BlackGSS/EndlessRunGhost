using Neisum.ScriptableEvents;
using UnityEngine;
using UnityEngine.Events;

public class ChunkShieldCollectListener : ScriptableListener<bool, ShieldCollectEvent, UnityEvent<bool>>
{
    [SerializeField] GameObject obstacleParent;
    private Collider[] obstacleColliders;

    private void Awake()
    {
        obstacleColliders = obstacleParent.GetComponentsInChildren<Collider>();
    }

    public void ActivateCollision(bool active)
    {
        for (int i = 0; i < obstacleColliders.Length; i++)
        {
            obstacleColliders[i].isTrigger = active;
        }
    }
}
