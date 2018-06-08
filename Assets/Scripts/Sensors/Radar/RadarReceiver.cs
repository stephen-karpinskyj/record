using UnityEngine;

public class RadarReceiver : MonoBehaviour
{
    public void ConsumeEcho(RadarEchoSnapshot echo)
    {
        Debug.Log("ConsumeEcho: " + echo);
    }
}
