using UnityEngine;

public class RadarEcho : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    void FixedUpdate()
    {
        transform.localScale += Vector3.one * Time.fixedDeltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.contacts[0].point);
        Destroy(gameObject);
    }
}
