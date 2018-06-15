using UnityEngine;

public class RadarWave : MonoBehaviour
{
    [SerializeField]
    RadarEcho echoPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.contacts[0].point;
        var echo = Instantiate(echoPrefab, contactPoint, Quaternion.identity);
        var entity = collision.gameObject.GetComponent<Entity>();
        echo.Initialise(entity.Snapshot(), contactPoint);
    }
}
