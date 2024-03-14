using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = "BuyItemCardEvent", menuName = "ScriptableEvents/BuyItemCard", order = 0 )]
    public class BuyItemCardEvent : BaseEvent<ItemCard> { }
}