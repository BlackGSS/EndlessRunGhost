using UnityEngine;

public class PowerUpCollectable : ItemSpawnable<IPowerUp>
{
    [SerializeField] AudioClip audioClip;
    private PlayerControl player;

    void OnTriggerEnter(Collider other)
    {
        if (player == null)
            player = other.GetComponentInParent<PlayerControl>();

        data.Apply(player);
        SoundSystem.PlaySound(audioClip, 0.5f);
        gameObject.SetActive(false);
    }
}