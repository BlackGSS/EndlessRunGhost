using System.Collections;
using System.Collections.Generic;
using Neisum.ScriptableEvents;
using UnityEngine;
using UnityEngine.Events;

public class BuyItemCardListener : ScriptableListener<ItemCard, BuyItemCardEvent, UnityEvent<ItemCard>>
{ }
