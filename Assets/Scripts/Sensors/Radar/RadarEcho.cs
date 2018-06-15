using UnityEngine;

public class RadarEcho : MonoBehaviour
{
    [SerializeField]
    Ring ring;

    EntitySnapshot originEntity;
    Vector2 originPoint;
    Vector2 contactPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        contactPoint = collision.contacts[0].point;
        collision.gameObject.GetComponent<RadarReceiver>().ConsumeEcho(Snapshot());
        ring.FadeOut();
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
}
