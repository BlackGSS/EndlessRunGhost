using Neisum.ScriptableEvents;
using UnityEngine;


[CreateAssetMenu(fileName = "New", menuName = "Scriptables/SessionData", order = 0)]
public class SessionData : ScriptableWithEvents<SessionData>
{
    public bool playerAlive = true;
    public Difficulties difficulty = Difficulties.EASY;
    public int score;

    public override void ResetVariables()
    {
        playerAlive = true;
        score = 0;
    }
}