using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpawnedEvent", menuName = "ScriptableEvents/PlayerEvent", order = 0)]
public class PlayerEvent : BaseEvent<PlayerControl>
{
    public PlayerControl player;
}