using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.BouncyBall
{
    public class CircleEdgeCollider : MonoBehaviour
    {
        public EdgeCollider2D edgeCollider;
        public List<Vector2> points;
        public float radius = 10;
        public int segments = 10;
        const float TAU = 6.28318530718f;

        private void Awake()
        {
            for (int pointIndex = 0; pointIndex < (segments + 1); pointIndex++)
            {
                float ang = (float)pointIndex / (segments + 1);
                float x = Mathf.Sin(ang * TAU) * radius;
                float y = Mathf.Cos(ang * TAU) * radius;
                Vector2 point = new Vector2(x, y);
                points.Add(point);
            }
            edgeCollider.points = points.ToArray();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}