using Neisum.ScriptableUpdaters;
using TMPro;
using UnityEngine;

public class DisplayPlayerMoneyUI : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] TextMeshProUGUI moneyText;

    public void ScriptableResponse(PlayerData data)
    {
        moneyText.text = data.money.ToString();
    }
}
