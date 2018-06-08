using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : BehaviourSingleton<UIPanelManager>
{
    [SerializeField]
    List<UIPanel> panelPrefabs;

    List<Transform> originalChildren = new List<Transform>();
    RectTransform rectTransform;

    void Awake()
    {
        GetComponentsInChildren(originalChildren);
        rectTransform = GetComponent<RectTransform>();
    }

    T GetPanelPrefab<T>() where T : UIPanel
    {
        var prefab = panelPrefabs.Find(p => p is T) as T;
        Debug.Assert(prefab != null, this);

        return prefab;
    }

    public T OpenPanel<T>(bool asModal = false) where T : UIPanel
    {
        if (asModal)
        {
            foreach (Transform t in transform)
            {
                if (!originalChildren.Contains(t))
                {
                    var p = t.GetComponent<UIPanel>();

                    if (p)
                    {
                        p.Close();
                    }
                }
            }
        }

        return GameObjectUtility.InstantiatePrefab(GetPanelPrefab<T>(), transform, false);
    }

    public Vector2 GlobalPositionToCanvasPosition(Camera camera, Vector3 globalPosition)
    {
        var viewportPosition = camera.WorldToViewportPoint(globalPosition);
        return new Vector2(
            (viewportPosition.x * rectTransform.sizeDelta.x),
            (viewportPosition.y * rectTransform.sizeDelta.y));
    }
}
