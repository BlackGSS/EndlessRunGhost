using Neisum.ScriptableUpdaters;
using UnityEngine;

[CreateAssetMenu(fileName = "New", menuName = "Scriptables/PlayerData", order = 0)]
public class PlayerData : InstantiableScriptable
{
    public float baseSpeed = 10;
    public float speed = 10;
	public float gravity = 12;
    public float jumpSpeed = 0;
    public int ammoAmount = 0;
    public bool isInvincible = false;
}