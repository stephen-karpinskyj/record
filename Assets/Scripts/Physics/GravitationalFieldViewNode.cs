using UnityEngine;

public class GravitationalFieldViewNode : MonoBehaviour
{
    const float GravitationalForceMagnitudeLimit = 0.001f;
    
    [SerializeField]
    string entityId;
    
    [SerializeField]
    string otherEntityId;

    [SerializeField]
    Color color = Color.white;
    
    [SerializeField]
    GravitationalFieldView prefab;
    
    void Start()
    {
        var a = PhysicsManager.Instance.GetEntity(entityId);
        var b = PhysicsManager.Instance.GetEntity(otherEntityId);
        var dist = PhysicsManager.CalculateDistance(a, b, GravitationalForceMagnitudeLimit);
        var view = GameObjectUtility.InstantiatePrefab(prefab, transform, false);
        view.transform.localPosition = Vector3.zero;
        view.SetScale(dist);
        view.SetColor(color);
    }
}
