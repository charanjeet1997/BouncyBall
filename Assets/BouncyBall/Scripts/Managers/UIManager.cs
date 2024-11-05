using System;
using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using ServiceLocatorFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Games.BouncyBall
{
    public class UIManager : MonoBehaviour
    {
        public GameObject restartPanel;
        public Text pointText;

        private void OnEnable()
        {
            ScoreManager.OnScoreChanged += OnUpdatePoints;
        }
        
        private void OnDisable()
        {
            ScoreManager.OnScoreChanged -= OnUpdatePoints;
        }

        public void OnEnableRestartPanel()
        {
            restartPanel.SetActive(!restartPanel.activeSelf);
            ServiceLocator.Current.Get<GameStateManager>().StartGame();
        }
        
        public void OnUpdatePoints(int points)
        {
            pointText.text = points.ToString();
        }
    }
}