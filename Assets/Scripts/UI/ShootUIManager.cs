using Neisum.ScriptableEvents;
using Neisum.ScriptableUpdaters;
using TMPro;
using UnityEngine;

public class ShootUIManager : CanvasGroupView, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] OnShootInputEvent onShootInputEvent;

    public void ScriptableResponse(PlayerData data)
    {
        FadeTo(data.ammoAmount > 0 ? 1 : 0);
        UpdateAmount(data.ammoAmount);
    }

    private void UpdateAmount(int amount)
    {
        amountText.text = $"x{amount}";
    }

    public void Fire()
    {
        onShootInputEvent.Raise(true);
    }
}
