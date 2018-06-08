using UnityEngine;
using Pixelplacement;

public class PositioningSignal : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    
    [SerializeField]
    float fadeOutDuration = 0.2f;

    [SerializeField]
    float fadeOutDelay = 0.2f;
    
    EntitySnapshot entity;

    void FixedUpdate()
    {
        transform.localScale += Vector3.one * Time.fixedDeltaTime * speed;
    }
    
    public void Initialise(EntitySnapshot entity)
    {
        this.entity = entity;
        FadeOut();
    }
    
    public PositioningSignalSnapshot Snapshot()
    {
        return new PositioningSignalSnapshot
        {
            entity = entity,
        };
    }
    
    void FadeOut()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var targetColor = spriteRenderer.color.SetAlpha(0f);
        Tween.Value(spriteRenderer.color, targetColor, (v) => spriteRenderer.color = v, fadeOutDuration, fadeOutDelay, Tween.EaseOutBack, completeCallback: () => Destroy(gameObject));
    }
}
