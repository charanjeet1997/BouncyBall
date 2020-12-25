using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class CircleEdgeCollider : MonoBehaviour
{
    public EdgeCollider2D edgeCollider;
    public List<Vector2> points;
    public float angle = 20;
    public float radius = 10;
    public int segments = 10;
    private void Awake()
    {
        for (int pointIndex = 0; pointIndex < (segments+1); pointIndex++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            Vector2 point = new Vector2(x, y);
            points.Add(point);
            angle += (360f / segments);
        }
        edgeCollider.points = points.ToArray();
    }
}
