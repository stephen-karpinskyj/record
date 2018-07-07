using UnityEngine;

public class WorldCamera : BehaviourSingleton<WorldCamera>
{
    public delegate void OnCamerZoomDelegate(float zoom);
    public event OnCamerZoomDelegate OnCameraZoom = delegate { };
    
    public float GetZoom()
    {
        return Camera.main.orthographicSize;
    }
    
    public void SetZoom(float zoom)
    {
        Camera.main.orthographicSize = zoom;
        OnCameraZoom(zoom);
    }
}
