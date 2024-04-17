using System;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "NewSessionData", menuName = "Scriptables/DifficultySettings", order = 0)]
public class DifficultySettings : ScriptableObject
{
    private int maxDifficult;
    [SerializeField]
    public int maxDifficultLevel
    {
        get
        {
            if (maxDifficult == 0)
            {
                Difficulties[] values = (Difficulties[])Enum.GetValues(typeof(Difficulties));
                maxDifficult = difficulties.Where(x => x.difficulty == values[values.Length - 1]).First().maxDificultyLevel;
            }
            return maxDifficult;
        }
        private set
        {
            maxDifficult = value;
        }
    }
    //TODO: It would be cool to have a score lever based on levels, not just *2 this value
    public int scoreToFirstLevel = 10;
    //Order them by Difficulty < Difficulty in inspector
    public DifficultiesConfig[] difficulties;
}