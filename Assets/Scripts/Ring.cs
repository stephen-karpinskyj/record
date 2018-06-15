using System;
using System.Collections;
using UnityEngine;
using Pixelplacement;

[RequireComponent(typeof(LineRenderer))]
public class Ring : MonoBehaviour
{
    [SerializeField]
    int pointCount = 8;

    [SerializeField]
    float initialRadius = 1f;
    
    [SerializeField]
    float growSpeed = 5f;

    [SerializeField]
    float fadeOutDuration = 0.2f;
    
    [SerializeField]
    float ttl;

    float radius;
    
    LineRenderer line;
    CircleCollider2D circle;

    public Action OnDestroy = delegate { };
    
	void Awake()
    {
        line = GetComponent<LineRenderer>();
        circle = GetComponent<CircleCollider2D>();

        SetRadius(initialRadius);
    }

    IEnumerator Start()
    {
        if (ttl > 0f)
        {
            yield return new WaitForSeconds(ttl);
            FadeOut();
        }
    }

    void FixedUpdate()
    {
        SetRadius(radius + Time.fixedDeltaTime * growSpeed);
    }

    public void FadeOut()
    {
        Destroy(GetComponent<Rigidbody2D>());
        var targetColor = line.startColor.SetAlpha(0f);
        Tween.Value(line.startColor, targetColor, SetColor, fadeOutDuration, 0f, Tween.EaseOutBack, completeCallback: HandleDestroy);
    }
    
    void SetRadius(float r)
    {
        radius = r;
        
        if (circle)
        {
            circle.radius = radius;
        }
        
        var points = MathUtility.GenerateCircle(pointCount, radius - line.widthMultiplier / 2f);
        line.positionCount = points.Length;
        line.SetPositions(points);
    }
    
    void SetColor(Color color)
    {
        line.startColor = color;
        line.endColor = color;
    }
    
    void HandleDestroy()
    {
        OnDestroy();
        Destroy(gameObject);
    }
}
