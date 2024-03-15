using System.Collections.Generic;
using UnityEngine;
using MEC;
using Neisum.ScriptableEvents;

[CreateAssetMenu(fileName = "ShieldPowerUp", menuName = "Scriptables/PowerUps/Shield", order = 0)]
public class ShieldPowerUpData : ScriptableObject, IPowerUp
{
    [SerializeField] PlayerDataUpdater playerData;
    [SerializeField] PowerUpCollectEvent powerUpCollectEvent;

    CoroutineHandle coroutineHandle;

    public float duration = 8f;

    public void Apply(PlayerControl player)
    {
        if (coroutineHandle != null)
            Timing.KillCoroutines(coroutineHandle);

        coroutineHandle = Timing.RunCoroutine(Affect(player));
    }

    IEnumerator<float> Affect(PlayerControl player)
    {
        powerUpCollectEvent.Raise(true);
        playerData.data.isInvincible = true;
        playerData.Notify();

        yield return Timing.WaitForSeconds(8f);

        playerData.data.isInvincible = false;
        playerData.Notify();
        powerUpCollectEvent.Raise(false);
    }
}