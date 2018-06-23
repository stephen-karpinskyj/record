using System.Collections;
using UnityEngine;

public class RandomShipController : MonoBehaviour
{
    [SerializeField]
    Thruster mainThruster;
    
    [SerializeField]
    Thruster cwThruster;
    
    [SerializeField]
    Thruster ccwThruster;
    
	void Start()
    {
        StartCoroutine(MainThrusterCoroutine());
        StartCoroutine(AttitudeThrusterCoroutine(cwThruster));
        StartCoroutine(AttitudeThrusterCoroutine(ccwThruster));
	}
    
    IEnumerator MainThrusterCoroutine()
    {
        while (true)
        {
            var r = Random.value;
            var throttle = r > 0.75f ? 0f : Random.Range(0f, 1f);
            mainThruster.SetThrottle(throttle);
            
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }

    IEnumerator AttitudeThrusterCoroutine(Thruster thruster)
    {
        while (true)
        {
            var r = Random.value;
            var throttle = r > 0.1f ? 0f : Random.Range(0f, 1f);
            thruster.SetThrottle(throttle);

            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
        }
    }
}
