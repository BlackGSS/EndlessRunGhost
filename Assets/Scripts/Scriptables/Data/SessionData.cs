using UnityEngine;

[CreateAssetMenu(fileName = "NewSessionData", menuName = "Scriptables/SessionData", order = 0)]
public class SessionData : InstantiableScriptable
{
    public int playerSelected;
    public bool playerAlive = true;
    public Difficulties difficulty = Difficulties.EASY;
    public float currentScore;
    public int currentDifficultLevel;
    public PlayerTypes playerPrefab;
}