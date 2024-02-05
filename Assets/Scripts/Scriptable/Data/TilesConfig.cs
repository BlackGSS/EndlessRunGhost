using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTilesconfig", menuName = "Scriptables/TilesConfig", order = 2)]
public class TilesConfig : ScriptableObject
{
	public float tileLength = 20.5f;
	public int amountTiles = 8;
	public int amountInitialTiles = 2;
	public int lastPrefabIndex = 0;
}
