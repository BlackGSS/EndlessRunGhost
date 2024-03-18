using System.Linq;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] StoreItemCardsPool uiManager;
    [SerializeField] CosmeticData[] cosmeticDatas;
    [SerializeField] PlayerDataUpdater playerDataUpdater;
    [SerializeField] Modal modalUI;

    private ItemCard cosmeticItemSelected;

    private void Start()
    {
        SpawnElements(cosmeticDatas);
    }

    private void SpawnElements(CosmeticData[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            ItemCard itemCard = uiManager.SpawnElement(elements[i]);

            if (playerDataUpdater.data.cosmeticsBuyed.Count > 0)
                itemCard.Buyed(playerDataUpdater.data.cosmeticsBuyed.Contains(elements[i]) ? true : false);

            if (playerDataUpdater.data.cosmeticsSelected.Count > 0 && playerDataUpdater.data.cosmeticsSelected.Contains(elements[i]))
                SelectItem(itemCard);
        }
    }

    public void SelectItem(ItemCard cosmetic)
    {
        playerDataUpdater.data.cosmeticsSelected.Clear();
        playerDataUpdater.data.cosmeticsSelected.Add(cosmetic.data);
        playerDataUpdater.Notify();
        cosmetic.SetToggleOn();
        cosmeticItemSelected = cosmetic;
    }

    public void BuyItem()
    {
        modalUI.Show(() => Buy());
    }

    private void Buy()
    {
        cosmeticItemSelected.Buyed(true);
        playerDataUpdater.data.money -= cosmeticItemSelected.data.price;
        playerDataUpdater.data.cosmeticsBuyed.Add(cosmeticItemSelected.data);
        playerDataUpdater.Notify();
    }
}

public class Cosmetic3DData
{
    public CosmeticData cosmeticData;
    public GameObject element3D;
}

