using UnityEngine;
using Neisum.ScriptableEvents;

public class PlayerFactory : MonoBehaviour
{
  [SerializeField] PlayerSpawn playerSpawned;
  [SerializeField] Transform playerSpawner;

  [SerializeField] SessionDataUpdater sessionDataUpdater;

  public void SpawnSessionPlayer()
  {
    PlayerControl player = Instantiate(sessionDataUpdater.data.playerPrefab.prefab, playerSpawner);
    playerSpawned.Raise(player);
  }
}