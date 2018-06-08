using UnityEngine;
using Pixelplacement;

public class RadarEcho : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float fadeOutDuration = 0.2f;

    EntitySnapshot originEntity;
    Vector2 originPoint;
    Vector2 contactPoint;
    
    void FixedUpdate()
    {
        transform.localScale += Vector3.one * Time.fixedDeltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        contactPoint = collision.contacts[0].point;
        collision.gameObject.GetComponent<RadarReceiver>().ConsumeEcho(Snapshot());
        FadeOut();
    }

    public void Initialise(EntitySnapshot entity, Vector2 point)
    {
        originEntity = entity;
        originPoint = point;
    }
    
    public RadarEchoSnapshot Snapshot()
    {
        return new RadarEchoSnapshot
        {
            originEntity = originEntity,
            originPoint = originPoint,
            contactPoint = contactPoint,
        };
    }
    
    void FadeOut()
    {
        Destroy(GetComponent<Rigidbody2D>());
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var targetColor = spriteRenderer.color.SetAlpha(0f);
        Tween.Value(spriteRenderer.color, targetColor, (v) => spriteRenderer.color = v, fadeOutDuration, 0f, Tween.EaseOutBack, completeCallback: () => Destroy(gameObject));
    }
}
