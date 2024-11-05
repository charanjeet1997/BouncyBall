using System;
using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using ModulerUISystem;
using UnityEngine;

namespace Games.BouncyBall
{
    public class Ball : MonoBehaviour, IGameStart, IGamePause, IGameOver
    {
        public Rigidbody2D rb;
        public float ballSpeed;
        Vector3 ballVelocity;
        [SerializeField] private ViewConfig gameOverViewConfig;

        private void OnEnable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Register(this);
        }

        private void OnDisable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Unregister(this);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "Obstacle")
            {
                this.transform.position = new Vector3(0, 0, 0);
                ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().GameOver();
                ModulerUISystem.UIManager.instance.ShowView(gameOverViewConfig);
            }
            else
            {
                ServiceLocatorFramework.ServiceLocator.Current.Get<ScoreManager>().AddScore();
            }   
        }

        public void StartGame()
        {
            transform.position = Vector2.zero;
            rb.AddForce(Vector2.up * ballSpeed * -1);
        }

        public void PauseGame()
        {
            ballVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
        }

        public void UnPauseGame()
        {
            rb.velocity = ballVelocity;
        }

        public void GameOver()
        {
            rb.velocity = Vector2.zero;
        }
    }
}