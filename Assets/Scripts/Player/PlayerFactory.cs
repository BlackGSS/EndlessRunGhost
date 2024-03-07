using UnityEngine;
using Neisum.ScriptableEvents;

public class PlayerFactory : MonoBehaviour
{
  [SerializeField] PlayerSpawn playerSpawned;

  [SerializeField] SessionDataUpdater sessionDataUpdater;

  public void SpawnSessionPlayer()
  {
    PlayerControl player = Instantiate(sessionDataUpdater.data.playerPrefab.prefab, transform);
    playerSpawned.Raise(player);
  }
}