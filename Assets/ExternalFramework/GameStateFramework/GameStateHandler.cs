using System;
using ServiceLocatorFramework;

namespace Games.GameStateFramework
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameStateHandler : MonoBehaviour
    {
        private GameStateManager manager;

        private void Start()
        {
            manager = ServiceLocator.Current.Get<GameStateManager>();
        }

        private void Update()
        {
            manager.Update();
        }

        private void FixedUpdate()
        {
            manager.FixedUpdate();
        }

        private void LateUpdate()
        {
            manager.LateUpdate();
        }
    }
}