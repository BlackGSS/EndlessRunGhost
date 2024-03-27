using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] StoreItemCardsPool itemsPool;
    [SerializeField] CosmeticData[] cosmeticDatas;
    [SerializeField] PlayerDataUpdater playerDataUpdater;
    [SerializeField] PlayerLoadSaveSystem playerLoadSaveSystem;
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
            ItemCard itemCard = itemsPool.SpawnElement(elements[i]);

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

    public void DeselectItem()
    {
        playerDataUpdater.data.cosmeticsSelected.Clear();
        playerDataUpdater.Notify();
        cosmeticItemSelected.SetToggleOff();
        cosmeticItemSelected = null;
    }

    public void BuyItem()
    {
        if (playerDataUpdater.data.money >= cosmeticItemSelected.data.price)
            modalUI.Show("Confirmamos?", "Confirmamos", () => Buy());
        else
            modalUI.Show("Ops no tienes dinero :(", "Continuar");
    }

    private void Buy()
    {
        if (playerDataUpdater.data.money >= cosmeticItemSelected.data.price)
        {
            cosmeticItemSelected.Buyed(true);
            playerDataUpdater.data.money -= cosmeticItemSelected.data.price;
            playerDataUpdater.data.cosmeticsBuyed.Add(cosmeticItemSelected.data);
            playerDataUpdater.Notify();
            playerLoadSaveSystem.SavePlayerData();
        }
    }

}

public class Cosmetic3DData
{
    public CosmeticData cosmeticData;
    public GameObject element3D;
}

