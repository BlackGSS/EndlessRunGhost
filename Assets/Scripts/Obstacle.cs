using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Collider[] obstacleCollider;
    [SerializeField] GameObject flag;

    void OnEnable()
    {
        ActiveCollider(true);
    }

    public void ApplyDamage(float damage)
    {
        ActiveCollider(false);
    }

    private void ActiveCollider(bool active)
    {
        for (int i = 0; i < obstacleCollider.Length; i++)
            obstacleCollider[i].enabled = active;

        if (flag != null)
            flag.SetActive(!active);
    }

    public void OnDisable()
    {
        ActiveCollider(true);
    }
}
