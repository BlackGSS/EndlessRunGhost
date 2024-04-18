using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Collider[] obstacleCollider;
    [SerializeField] GameObject flag;
    [SerializeField] AudioClip hitClip;
    
    private bool collidersEnabled;
    public bool CollidersEnabled { get { return collidersEnabled; } }

    void OnEnable()
    {
        ActiveCollider(true);
    }

    public void ApplyDamage(float damage)
    {
        SoundSystem.PlaySound(hitClip, 0.4f);
        ActiveCollider(false);
    }

    public void ActiveCollider(bool active)
    {
        collidersEnabled = active;
        for (int i = 0; i < obstacleCollider.Length; i++)
        {
                obstacleCollider[i].isTrigger = !active;
        }

        if (flag != null)
            flag.SetActive(!active);
    }
}
