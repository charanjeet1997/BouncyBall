using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed;
    private void OnEnable()
    {
        rb.AddForce(Vector2.up * ballSpeed * -1);
    }
}
