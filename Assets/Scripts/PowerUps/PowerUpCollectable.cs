using UnityEngine;

public class PowerUpCollectable : MonoBehaviour
{
    [SerializeField] IPowerUp powerUp;

    private PlayerControl player;

    public void Initialize(IPowerUp newPowerUp)
    {
        powerUp = newPowerUp;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (player == null)
            player = other.GetComponentInParent<PlayerControl>();

        powerUp.Apply(player);
        gameObject.SetActive(false);
    }
}
