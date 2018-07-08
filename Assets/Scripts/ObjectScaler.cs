using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField]
    float size = 1f;

    LineRenderer line;
    TrailRenderer trail;
    
    void OnEnable()
    {
        UpdateLineWidth(WorldCamera.Instance.GetZoom());
        WorldCamera.Instance.OnCameraZoom += HandleCameraZoom;
    }

    void OnDisable()
    {
        if (WorldCamera.Exists)
        {
            WorldCamera.Instance.OnCameraZoom -= HandleCameraZoom;
        }
    }

    void UpdateLineWidth(float cameraZoom)
    {
        transform.localScale = Vector3.one * cameraZoom * size;
    }
    
    void HandleCameraZoom(float zoom)
    {
        UpdateLineWidth(zoom);
    }
}
