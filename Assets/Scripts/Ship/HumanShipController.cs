using UnityEngine;

public class HumanShipController : MonoBehaviour
{
    [SerializeField]
    Thruster mainThruster;
    
    [SerializeField]
    Thruster cwThruster;
    
    [SerializeField]
    Thruster ccwThruster;
    
	void Update()
    {
        ccwThruster.SetThrottle(0f);
        cwThruster.SetThrottle(0f);
        mainThruster.SetThrottle(0f);
        
        var inputPos = Input.mousePosition;
        
        if (Input.GetMouseButton(0))
        {
            var x = inputPos.x / Screen.width;
            var y = inputPos.y / Screen.height;

            if (y < 0.5f)
            {
                var throttle = Mathf.Clamp(y * 3f, 0, 1 / 3f);
                
                if (x < 0.25f)
                {
                    ccwThruster.SetThrottle(throttle);
                }
                else if (x > 0.75f)
                {
                    cwThruster.SetThrottle(throttle);
                }
                else
                {
                    mainThruster.SetThrottle(throttle);
                }
            }
        }
	}
}
