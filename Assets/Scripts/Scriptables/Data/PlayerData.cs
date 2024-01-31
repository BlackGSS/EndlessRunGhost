using Neisum.ScriptableUpdaters;
using UnityEngine;

[CreateAssetMenu(fileName = "New", menuName = "Scriptables/PlayerData", order = 0)]
public class PlayerData : InstantiableScriptable
{
    public float speed = 10;
	public float gravity = 12;
    public float jumpSpeed = 0;
    public Transform playerTransform;
}