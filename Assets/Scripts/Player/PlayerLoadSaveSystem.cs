using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLoadSaveSystem : MonoBehaviour
{
    [SerializeField] PlayerDataUpdater value;
    [SerializeField] AvailableCosmetics availableCosmetics;

    private List<int> emptyList = new List<int>();

    void OnEnable()
    {
        PlayerDataSerializable loadedData = SaveSystem<PlayerDataSerializable>.LoadPlayerData("/playerData.ghost");
        if (loadedData != null)
        {
            value.template.money = loadedData.money;
            if (loadedData.cosmeticsIdSelected.Count > 0)
                value.template.cosmeticsBuyed = availableCosmetics.cosmetics.Where(x => loadedData.cosmeticsIdBuyed.Contains(x.id)).ToList();
            value.template.money = loadedData.money;
            if (loadedData.cosmeticsIdSelected.Count > 0)
                value.template.cosmeticsSelected = availableCosmetics.cosmetics.Where(x => loadedData.cosmeticsIdSelected.Contains(x.id)).ToList();
        }

        value.Initialize();
    }

    void Start()
    {
        value.Notify();
    }

    public void SaveAllPlayerData()
    {
        PlayerDataSerializable playerDataSerializable = new PlayerDataSerializable(value.data.money, value.data.cosmeticsBuyed.Count > 0 ? value.data.cosmeticsBuyed.Select(x => x.id).ToList() : emptyList, value.data.cosmeticsSelected.Count > 0 ? value.data.cosmeticsSelected.Select(x => x.id).ToList() : emptyList);
        SaveSystem<PlayerDataSerializable>.SavePlayerData(playerDataSerializable, "/playerData.ghost");
    }

    void OnDestroy()
    {
        SaveAllPlayerData();
    }
}