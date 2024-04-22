using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    [SerializeField] PlayerDataUpdater playerDataUpdater;
    [SerializeField] LayerMask layer;
    [SerializeField] Vector3 offset;
    [SerializeField] float rayDistance = 10f;
    private Material wallMaterial;
    private Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            // var dir = transform.position - cam.transform.position;
            // var ray = new Ray(transform.position, dir.normalized);
            // Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, cam.transform.position.z), transform.forward, out RaycastHit hitInfo, rayDistance, layer))
            {
                // Debug.Log(hitInfo.transform.gameObject.name);
                // Debug.Log("Colliders Enabled" + hitInfo.transform.gameObject.GetComponent<Obstacle>().CollidersEnabled);
                if (!hitInfo.transform.gameObject.GetComponent<Obstacle>().CollidersEnabled || playerDataUpdater.data.isInvincible)
                {
                    wallMaterial = hitInfo.transform.gameObject.GetComponentInChildren<Renderer>().material;
                    wallMaterial.SetFloat(SizeID, 1f);
                }
                else
                {
                    wallMaterial?.SetFloat(SizeID, 0);
                }
            }
            else
            {
                wallMaterial?.SetFloat(SizeID, 0);
            }

            var view = cam.WorldToViewportPoint(transform.position) + offset;
            wallMaterial?.SetVector(PosID, view);
        }
    }

    public void SetCamera(Camera newCamera)
    {
        cam = newCamera;
    }
}
