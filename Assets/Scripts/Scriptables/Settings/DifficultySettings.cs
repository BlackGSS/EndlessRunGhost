using System;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "NewSessionData", menuName = "Scriptables/DifficultySettings", order = 0)]
public class DifficultySettings : ScriptableObject
{
    [SerializeField]
    public int maxDifficultLevel
    {
        get
        {
            if (maxDifficultLevel == 0)
            {
                Difficulties[] values = (Difficulties[])Enum.GetValues(typeof(Difficulties));
                maxDifficultLevel = difficulties.Where(x => x.difficulty == values[values.Length - 1]).First().maxDificultyLevel;
            }
            return maxDifficultLevel;
        }
        private set
        {
            maxDifficultLevel = value;
        }
    }
    public int scoreToNextLevel = 10;
    //Order them by Difficulty < Difficulty in inspector
    public DifficultiesRange[] difficulties;
}