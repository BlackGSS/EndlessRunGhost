using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemCardsPool : GenericDataPool<ItemCard, CosmeticData>
{
    [SerializeField] ItemCard prefab;
    [SerializeField] Transform contentTransform;

    public ItemCard SpawnElement(CosmeticData cosmeticData)
    {
        Debug.Log(contentTransform.name);
        return SpawnElement(cosmeticData, prefab, contentTransform);
    }
}