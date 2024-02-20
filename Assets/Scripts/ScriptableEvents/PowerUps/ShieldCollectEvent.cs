using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "ShieldCollectEvent", menuName = "ScriptableEvents/ShieldCollect", order = 0)]
    public class ShieldCollectEvent : BaseEvent<bool> { }
}