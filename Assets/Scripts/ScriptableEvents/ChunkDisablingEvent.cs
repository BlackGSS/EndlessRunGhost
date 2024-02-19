using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "ChunkDisablingEventEvent", menuName = "ScriptableEvents/ChunkDisablingEvent", order = 0)]
    public class ChunkDisablingEvent : BaseEvent<Chunk> { }
}