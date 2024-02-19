using UnityEngine;
namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "ChunkEnablingEvent", menuName = "ScriptableEvents/ChunkEnabling", order = 0)]
    public class ChunkEnablingEvent : BaseEvent<Chunk> { }
}