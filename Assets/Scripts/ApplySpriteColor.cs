using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ApplySpriteColor : MonoBehaviour
{
	void Awake()
    {
        var rend = GetComponent<SpriteRenderer>();
        rend.material.color = rend.color;
	}
}
