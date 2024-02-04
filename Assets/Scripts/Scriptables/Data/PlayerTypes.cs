using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerType", menuName = "Scriptables/PlayerType", order = 0)]
public class PlayerTypes : ScriptableObject
{
    public string characterName;
    public PlayerControl prefab;
    // public string characterName;
    
    //This will have the texture associated to the ghost
}