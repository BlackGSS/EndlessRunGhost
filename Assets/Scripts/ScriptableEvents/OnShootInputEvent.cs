using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "OnShootEvent", menuName = "ScriptableEvents/OnShoot", order = 0 )]
    public class OnShootInputEvent : BaseEvent<bool> { }
}