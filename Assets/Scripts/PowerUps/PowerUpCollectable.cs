using TNRD;
using UnityEngine;

public class PowerUpCollectable : MonoBehaviour
{
    [SerializeField] SerializableInterface<IPowerUp> powerUp;

    private PlayerControl player;

    public void Initialize(IPowerUp newPowerUp)
    {
        powerUp.Value = newPowerUp;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (player == null)
            player = other.GetComponentInParent<PlayerControl>();

        powerUp.Value.Apply(player);
        gameObject.SetActive(false);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}