using System.Collections;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField]
    Engine engine;
    
    [SerializeField]
    SteeringSystem steering;
    
	void Start()
    {
        StartCoroutine(ThrottleCoroutine());
        StartCoroutine(SteeringCoroutine());
	}
    
    IEnumerator ThrottleCoroutine()
    {
        while (true)
        {
            var tR = Random.value;
            var throttle = Random.Range(0.25f, 1f) * (tR < 0.333f ? 1f : -0.5f);
            engine.SetThrottle(throttle);
            
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }
    
    IEnumerator SteeringCoroutine()
    {
        while (true)
        {
            var dR = Random.value;
            var direction = dR < 0.333f ? 0f : dR < 0.666f ? -1f : 1f;
            var angle = Random.Range(5f, 15f) * direction;
            steering.SetAngle(angle);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
