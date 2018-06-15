using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float lerpSpeed = 3f;
    
    void FixedUpdate()
    {
        var newPosition = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * lerpSpeed);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
