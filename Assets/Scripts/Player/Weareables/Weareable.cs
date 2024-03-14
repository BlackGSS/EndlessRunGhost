using Neisum.ScriptableUpdaters;
using UnityEngine;

public class Weareable : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] CosmeticData cosmeticData;
    [SerializeField] MeshRenderer mesh;

    void Start()
    {
        mesh.enabled = false;
    }

    public void ScriptableResponse(PlayerData data)
    {
        if (data.cosmeticsSelected.Count > 0)
        {
            mesh.enabled = data.cosmeticsSelected.Contains(cosmeticData) ? true : false;
        }
    }
}
