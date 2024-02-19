using UnityEngine;
using Neisum.ScriptableEvents;

public class PlayerFactory : MonoBehaviour
{
  [SerializeField]
  private PlayerSpawn playerSpawned;

  [SerializeField] SessionDataUpdater sessionDataUpdater;

  public void SpawnSessionPlayer()
  {
    PlayerControl player = Instantiate(sessionDataUpdater.data.playerPrefab.prefab, transform.position, Quaternion.Euler(Vector3.zero));
    playerSpawned.Raise(player);
  }
}