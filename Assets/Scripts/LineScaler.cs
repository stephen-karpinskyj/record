using UnityEngine;

public class LineScaler : MonoBehaviour
{
    const float BaseSize = 0.01f;

    LineRenderer line;
    TrailRenderer trail;
    
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        trail = GetComponent<TrailRenderer>();
    }

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
        var width = cameraZoom * BaseSize;

        if (line)
        {
            line.widthMultiplier = width;
        }
        
        if (trail)
        {
            trail.widthMultiplier = width;
        }
    }
    
    void HandleCameraZoom(float zoom)
    {
        UpdateLineWidth(zoom);
    }
}
