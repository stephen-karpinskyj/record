using UnityEngine;

public class GravitationalFieldView : MonoBehaviour
{
    [SerializeField]
    Color color = Color.white;
    
    SpriteRenderer[] sprites;
    
    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        SetColor(color);
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
