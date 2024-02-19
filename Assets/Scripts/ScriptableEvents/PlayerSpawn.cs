using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "PlayerSpawnEvent", menuName = "ScriptableEvents/PlayerSpawn", order = 0)]
    public class PlayerSpawn : BaseEvent<PlayerControl>
    { }
}