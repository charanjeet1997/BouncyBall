using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BallCollider : MonoBehaviour
{
    public Image restartGame;
    public UnityEvent OnBallDestroy;
    public UnityEvent OnAddPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            this.gameObject.SetActive(false);
            OnBallDestroy?.Invoke();
        }
        else
        {
            OnAddPoint?.Invoke();
        }   
    }
}
