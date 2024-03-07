using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    public void ApplyDamage(float damage)
    {
        //TODO: Maybe it would be nice to change the texture for the trans flag
        gameObject.SetActive(false);
    }
}
