using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Collider obstacleCollider;
    [SerializeField] GameObject flag;
    public void ApplyDamage(float damage)
    {
        gameObject.SetActive(false);
        obstacleCollider.enabled = false;
        if (flag != null)
            flag.SetActive(true);
    }

    void OnDisable()
    {
        obstacleCollider.enabled = true;
        if (flag != null)
            flag.SetActive(false);
    }
}
