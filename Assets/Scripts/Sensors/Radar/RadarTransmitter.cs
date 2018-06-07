using System.Collections;
using UnityEngine;

public class RadarTransmitter : MonoBehaviour
{
    [SerializeField]
    float rate = 2f;

    [SerializeField]
    RadarWave wavePrefab;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
            EmitWave();
        }
    }

    void EmitWave()
    {
        Instantiate(wavePrefab, transform.position, transform.rotation);
    }
}
