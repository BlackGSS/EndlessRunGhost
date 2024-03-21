using UnityEngine;
using TNRD;

[CreateAssetMenu(fileName = "NewSessionData", menuName = "Scriptables/SessionData", order = 0)]
public class SessionData : InstantiableScriptable
{
    public int playerSelected;
    public bool playerAlive = true;
    public Difficulties difficulty = Difficulties.EASY;
    public int currentScore;
    public int currentDifficultLevel;
    public int currentMoneyCollected;
    public PlayerTypes playerPrefab;

    [Header("PowerUps Setup")]
    public int minChunksToPowerUp = 8;
    public int maxChunksToPowerUp = 12;
    public PowerUpDataPrefab[] availablePowerUps;
}

[System.Serializable]
public class PowerUpDataPrefab
{
    public SerializableInterface<IPowerUp> powerUpData;
    public PowerUpCollectable prefab;
}