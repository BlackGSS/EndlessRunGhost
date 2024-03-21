using System.Collections.Generic;
using System.Linq;
using Neisum.ScriptableUpdaters;
using UnityEngine;
using DG.Tweening;

public class BuyButton : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] CanvasGroup button;

    public void ScriptableResponse(PlayerData data)
    {
        if (data.cosmeticsSelected.Count > 0)
        {
            IEnumerable<CosmeticData> itemsInCommon = data.cosmeticsSelected.Intersect(data.cosmeticsBuyed);
            button.DOFade(!itemsInCommon.Any() ? 1 : 0, 0.2f);
            button.transform.DOShakeScale(0.2f, 0.4f, 6, 0);
        }
        else
        {
            button.DOFade(0, 0.2f);
        }
    }
}
