using Neisum.ScriptableUpdaters;
using TMPro;
using UnityEngine;

public class CoinsCollectedUI : MonoBehaviour, IScriptableUpdaterListener<SessionData>
{
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    [SerializeField] TextMeshProUGUI coinAmountText;

    void Start()
    {
        coinAmountText.text = "0";
    }
    
    public void ScriptableResponse(SessionData data)
    {
        coinAmountText.text = data.currentMoneyCollected.ToString();
    }
}
