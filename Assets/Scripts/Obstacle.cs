using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Collider obstacleCollider;
    [SerializeField] GameObject flag;
    public void ApplyDamage(float damage)
    {
        //TODO: Maybe it would be nice to change the texture for the trans flag
        gameObject.SetActive(false);
        obstacleCollider.enabled = false;
        flag.SetActive(true);
    }

    void OnDisable()
    {
        obstacleCollider.enabled = true;
        flag.SetActive(false);
    }
}
