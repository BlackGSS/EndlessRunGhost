using Neisum.ScriptableEvents;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSessionData", menuName = "Scriptables/SessionData", order = 0)]
public class SessionData : ScriptableWithEvents<SessionData>
{
    // public bool isGamePlaying;
    public bool playerAlive = true;
    public Difficulties difficulty = Difficulties.EASY;
    public float currentScore;
    public int currentDifficultLevel;

    public override void ResetVariables()
    {
        playerAlive = true;
        difficulty = Difficulties.EASY;
        currentScore = 0;
        currentDifficultLevel = 0;
    }
}