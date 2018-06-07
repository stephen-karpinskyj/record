using System.Collections;
using UnityEngine;

public class RadarWave : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float ttl = 5f;

    [SerializeField]
    RadarEcho echoPrefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.localScale += Vector3.one * Time.fixedDeltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.contacts[0].point;
        Instantiate(echoPrefab, contactPoint, Quaternion.identity);
    }
}
