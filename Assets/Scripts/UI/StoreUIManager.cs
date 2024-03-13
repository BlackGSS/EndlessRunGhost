using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUIManager : GenericDataPool<ItemCard, CosmeticData>
{
    [SerializeField] ItemCard prefab;
    [SerializeField] Transform contentTransform;

    public ItemCard SpawnElement(CosmeticData cosmeticData)
    {
        Debug.Log(contentTransform.name);
        return SpawnElement(cosmeticData, prefab, contentTransform);
    }
}