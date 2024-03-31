using UnityEngine;
using Neisum.ScriptableEvents;

[CreateAssetMenu(fileName = "ShootPowerUp", menuName = "Scriptables/PowerUps/Shoot", order = 0)]
public class ShootPowerUpData : ScriptableObject, IPowerUp
{ 
    [SerializeField] PlayerDataUpdater playerData;

    public int ammoAmount = 2;

    public void Apply(PlayerControl player)
    {
        Affect(player);
    }

    private void Affect(PlayerControl player)
    {
        playerData.data.ammoAmount += ammoAmount;
        playerData.Notify();
    }
}