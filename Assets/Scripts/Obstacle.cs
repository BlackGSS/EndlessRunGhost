using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Collider[] obstacleCollider;
    [SerializeField] GameObject flag;
    [SerializeField] AudioClip hitClip;

    void OnEnable()
    {
        ActiveCollider(true);
    }

    public void ApplyDamage(float damage)
    {
        SoundSystem.PlaySound(hitClip, 0.5f);
        ActiveCollider(false);
    }

    public void ActiveCollider(bool active)
    {
        for (int i = 0; i < obstacleCollider.Length; i++)
        {
            if (obstacleCollider[i].enabled != active)
                obstacleCollider[i].enabled = active;
        }

        if (flag != null)
            flag.SetActive(!active);
    }
}
