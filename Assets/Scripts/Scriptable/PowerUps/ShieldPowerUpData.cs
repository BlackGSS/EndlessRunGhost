using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

[CreateAssetMenu(fileName = "ShieldPowerUp", menuName = "Scriptables/PowerUps/Shield", order = 0)]
public class ShieldPowerUpData : ScriptableObject, IPowerUp
{
    [SerializeField] PlayerDataUpdater playerData;
    public float duration = 8f;

    public void Apply(PlayerControl player)
    {
        Timing.RunCoroutine(Trying());
    }

    IEnumerator<float> Trying()
    {
        playerData.data.isInvincible = true;
        playerData.Notify();
        yield return Timing.WaitForSeconds(8f);

        playerData.data.isInvincible = false;
        playerData.Notify();
    }
}