using System.Linq;
using UnityEngine;

public class PlayerLoadSaveSystem : MonoBehaviour
{
    [SerializeField] PlayerDataUpdater value;
    [SerializeField] AvailableCosmetics availableCosmetics;

    void Awake()
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

    void OnDestroy()
    {
        PlayerDataSerializable playerDataSerializable = new PlayerDataSerializable(value.data.money, value.data.cosmeticsBuyed.Select(x => x.id).ToList(), value.data.cosmeticsSelected.Select(x => x.id).ToList());
        SaveSystem<PlayerDataSerializable>.SavePlayerData(playerDataSerializable, "/playerData.ghost");
        value.ResetVariables();
    }
}