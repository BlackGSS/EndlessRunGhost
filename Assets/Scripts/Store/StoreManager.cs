using System.Linq;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] StoreItemCardsPool uiManager;
    [SerializeField] CosmeticData[] cosmeticDatas;
    [SerializeField] PlayerDataUpdater playerDataUpdater;

    private void Start()
    {
        if (playerDataUpdater.data.cosmeticsBuyed.Count > 0)
            SpawnElements(cosmeticDatas.Where(x => !cosmeticDatas.Contains(x)).ToArray());
        else
            SpawnElements(cosmeticDatas);
    }

    private void SpawnElements(CosmeticData[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            ItemCard itemCard = uiManager.SpawnElement(elements[i]);
            itemCard.SetPrice();
            itemCard.SetImage();
        }
    }

    public void SelectItem(ItemCard cosmetic)
    {
        playerDataUpdater.data.cosmeticsSelected.Clear();
        playerDataUpdater.data.cosmeticsSelected.Add(cosmetic.data);
        playerDataUpdater.Notify();

        if (playerDataUpdater.data.money >= cosmetic.data.price)
            BuyItem(cosmetic);
    }

    private void BuyItem(ItemCard cosmetic)
    {
        playerDataUpdater.data.money -= cosmetic.data.price;
        playerDataUpdater.Notify();

        // itemCard.
    }
}

public class Cosmetic3DData
{
    public CosmeticData cosmeticData;
    public GameObject element3D;
}

