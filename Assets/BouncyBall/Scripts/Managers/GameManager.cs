using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using ServiceLocatorFramework;
using UnityEngine;

namespace Games.BouncyBall
{
    public class GameManager : MonoBehaviour
    {
        [ContextMenu("Start Game")]
        public void StartGame()
        {
            ServiceLocator.Current.Get<ScoreManager>().ResetScore();
            ServiceLocator.Current.Get<GameStateManager>().StartGame();
        }

        public void EndGame()
        {
            // End game logic here
        }
    }
}