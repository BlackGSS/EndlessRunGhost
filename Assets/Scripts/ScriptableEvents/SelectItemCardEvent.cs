using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "SelectItemCardEvent", menuName = "ScriptableEvents/SelectItemCardEvent", order = 0 )]
    public class SelectItemCardEvent : BaseEvent<ItemCard> { }
}