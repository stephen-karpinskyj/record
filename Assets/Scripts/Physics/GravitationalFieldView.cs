using UnityEngine;

public class GravitationalFieldView : MonoBehaviour
{
    SpriteRenderer[] sprites;
    
    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }
    
    public void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }
    
    public void SetColor(Color color)
    {
        foreach (var s in sprites)
        {
            s.color = color;
        }
    }
}
