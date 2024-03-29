using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/CosmeticData")]
[System.Serializable]
public class CosmeticData : ScriptableObject
{
    public int id;
    public Sprite image;
    public int price;
    public bool renameOnValidate = false;

    private void OnValidate()
    {
        if (renameOnValidate)
        {
            string thisFileNewName = id + "_" + this.name;
            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
            UnityEditor.AssetDatabase.RenameAsset(assetPath, thisFileNewName);
            renameOnValidate = true;
        }
    }
}
