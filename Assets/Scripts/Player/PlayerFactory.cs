using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
  [SerializeField]
  private PlayerEvent playerSpawned;

  [SerializeField] SessionDataUpdater sessionDataUpdater;

  public void SpawnSessionPlayer()
  {
    PlayerControl player = Instantiate(sessionDataUpdater.data.playerPrefab.prefab, transform.position, Quaternion.Euler(Vector3.zero));
    playerSpawned.Raise(player);
  }
}
