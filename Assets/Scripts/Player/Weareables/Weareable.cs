using Neisum.ScriptableUpdaters;
using UnityEngine;

public class Weareable : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
    [SerializeField] CosmeticData cosmeticData;
    private MeshRenderer mesh;

    void Awake()
    {
        if (mesh == null)
            mesh = TryGetComponent(out MeshRenderer meshComponent) ? meshComponent : transform.GetComponentInChildren<MeshRenderer>();
    }

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
        else
        {
            mesh.enabled = false;
        }
    }
}
