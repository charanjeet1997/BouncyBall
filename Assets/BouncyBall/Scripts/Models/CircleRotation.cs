using System;
using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using UnityEngine;

namespace Games.BouncyBall
{
    public class CircleRotation : MonoBehaviour, IGameStart, IGameOver, IGameTick
    {
        public float rotationSpeed = 0.5f;
        float rotationDirection = 1;
        Vector2 mousePosition;

        [SerializeField] bool canRotate = false;

        private void OnEnable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Register(this);
        }

        private void OnDisable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Unregister(this);
        }

        private void UpdateCircleRotation()
        {
            if (Input.GetMouseButton(0) && canRotate)
            {
                mousePosition = Input.mousePosition;
                if (mousePosition.x > Screen.width / 2)
                {
                    rotationDirection = -1;
                    RotateCircle();
                }
                else
                {
                    rotationDirection = 1;
                    RotateCircle();
                }
            }
        }

        private void RotateCircle()
        {
            transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection);
        }

        public void StartGame()
        {
            canRotate = true;
        }

        public void GameOver()
        {
            canRotate = false;
        }

        public void Tick()
        {
            UpdateCircleRotation();
        }
    }
}