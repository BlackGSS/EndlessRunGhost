using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    public void ApplyDamage()
    {
        gameObject.SetActive(false);
    }
}
