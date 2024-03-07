using UnityEngine;
using Neisum.ScriptableEvents;

[CreateAssetMenu(fileName = "ShootPowerUp", menuName = "Scriptables/PowerUps/Shoot", order = 0)]
public class ShootPowerUpData : ScriptableObject, IPowerUp
{ 
    [SerializeField] PlayerDataUpdater playerData;
    [SerializeField] PowerUpCollectEvent powerUpCollectEvent;

    public int ammoAmount = 2;

    public void Apply(PlayerControl player)
    {
        Affect(player);
    }

    private void Affect(PlayerControl player)
    {
        powerUpCollectEvent.Raise(true);
        playerData.data.ammoAmount += ammoAmount;
        //TODO: UI se activa al ser notificada con este playerData y que el ammoAmount sea mayor a 0 
        playerData.Notify();
    }
}