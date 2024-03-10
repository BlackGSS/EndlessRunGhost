using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Scriptables/BulletConfig", order = 2)]
public class BulletConfig : ScriptableObject
{
    public int damage = 1;
    public float speed = 8;
    public float aliveTime = 8f;
    
}
