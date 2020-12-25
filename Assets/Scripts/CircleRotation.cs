using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    float rotationDirection = 1;
    Vector2 mousePosition;
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            if(mousePosition.x > Screen.width/2)
            {
                rotationDirection = -1;
                transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection);
            }
            else
            {
                rotationDirection = 1;
                transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection);
            }
        }
    }
}
