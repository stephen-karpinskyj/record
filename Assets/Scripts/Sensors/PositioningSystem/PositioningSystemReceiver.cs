using System.Collections;
using UnityEngine;

public class PositioningSystemReceiver : MonoBehaviour
{
    [SerializeField]
    float frequency = 2f;

    [SerializeField]
    PositioningSignal signalPrefab;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);
            var signal = Instantiate(signalPrefab, transform.position, transform.rotation);
            signal.Initialise(GetComponentInParent<Entity>().Snapshot());
            ConsumeSignal(signal.Snapshot());
        }
    }

    public void ConsumeSignal(PositioningSignalSnapshot signal)
    {
        Debug.Log("ConsumeSignal: " + signal);
    }
}
