using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty", menuName = "Scriptables/Difficulty Range", order = 1)]
public class DifficultiesConfig : ScriptableObject
{
    public Difficulties difficulty;
    public int minDificultyLevel;
    public int maxDificultyLevel;
    public Sprite levelSprite;
    public float multiplierToNextLevel = 2;
}