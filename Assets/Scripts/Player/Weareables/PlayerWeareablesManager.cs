using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Neisum.ScriptableUpdaters;
using UnityEngine;

public class PlayerWeareablesManager : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] Cosmetic3DData[] cosmetics3DData;
    private List<Cosmetic3DData> currentCosmeticsSelected = new List<Cosmetic3DData>();

    public void ScriptableResponse(PlayerData data)
    {
        if (data.cosmeticsSelected.Count > 0)
        {
            currentCosmeticsSelected = cosmetics3DData.Where(x => data.cosmeticsSelected.Contains(x.cosmeticData)).ToList();
            for (int i = 0; i < cosmetics3DData.Length; i++)
            {
                if (currentCosmeticsSelected.Contains(cosmetics3DData[i]))
                    currentCosmeticsSelected[i].element3D.SetActive(true);
            }
        }
    }
}
