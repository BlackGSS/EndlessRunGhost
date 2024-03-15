using TNRD;
using UnityEngine;

public class PowerUpCollectable : ItemSpawnable<IPowerUp>
{
    private PlayerControl player;

    void OnTriggerEnter(Collider other)
    {
        if (player == null)
            player = other.GetComponentInParent<PlayerControl>();

        data.Apply(player);
        gameObject.SetActive(false);
    }
}