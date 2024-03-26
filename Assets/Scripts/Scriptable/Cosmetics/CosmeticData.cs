using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/CosmeticData")] [System.Serializable]
public class CosmeticData : ScriptableObject
{
    public int id;
    public Sprite image;
    public int price;
}
