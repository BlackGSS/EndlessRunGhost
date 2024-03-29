using System.Collections.Generic;
using Neisum.ScriptableUpdaters;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptables/PlayerData", order = 0)]
public class PlayerData : InstantiableScriptable
{
    public float baseSpeed = 10;
    public float speed = 10;
    public float gravity = 12;
    public float jumpSpeed = 0;
    public int ammoAmount = 0;
    public bool isInvincible = false;
    public int money = 0;
    public List<CosmeticData> cosmeticsBuyed;
    public List<CosmeticData> cosmeticsSelected;
}

[System.Serializable]
public class PlayerDataSerializable : DataSerializable
{
    public int money;
    public List<int> cosmeticsIdBuyed;
    public List<int> cosmeticsIdSelected;

    public PlayerDataSerializable(int _money, List<int> _cosmeticsBuyed, List<int> _cosmeticsSelected)
    {
        money = _money;
        cosmeticsIdBuyed = _cosmeticsBuyed;
        cosmeticsIdSelected = _cosmeticsSelected;
    }
}