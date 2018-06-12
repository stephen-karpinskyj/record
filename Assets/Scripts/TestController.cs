using System.Collections;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField]
    Engine engine;
    
    [SerializeField]
    SteeringSystem steering;

    bool forward;
    
	IEnumerator Start()
    {
        while (true)
        {
            forward = !forward;
            var throttle = Random.Range(0.8f, 1f) * (forward ? 1f : -0.5f);
            engine.SetThrottle(throttle);

            var r = Random.value;
            var direction = r < 0.5f ? 0f : r < 0.75f ? -1f : 1f;
            var angle = Random.Range(10f, 15f) * direction;
            steering.SetAngle(angle);
            
            yield return new WaitForSeconds(Random.Range(3f, 3f));
        }
	}
}
