using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField]
    Vector3 magnitude = Vector3.up;

    [SerializeField]
    float speed = 5f;

    void Update()
    {
        transform.localPosition = Mathf.Sin(Time.timeSinceLevelLoad * speed) * magnitude;
    }
}
