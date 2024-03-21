using UnityEngine;

public class CoinCollectable : ItemSpawnable<CoinData>
{
    [SerializeField] SessionDataUpdater sessionDataUpdater;
    
    void OnTriggerEnter()
    {
        sessionDataUpdater.data.currentMoneyCollected += data.coinAmount;
        gameObject.SetActive(false);
    }
}
