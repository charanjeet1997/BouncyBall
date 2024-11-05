using System;
using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using ServiceLocatorFramework;
using UnityEngine;

namespace Games.BouncyBall
{
    public class ScoreManager : MonoBehaviour, IGameOver
    {
        public static ScoreManager instance;
        
        [SerializeField] private int score = 0;
        [SerializeField] private int highScore = 0;
        
        public static Action<int> OnScoreChanged;
        public static Action<int> OnHighScoreChanged;

        public int Score => score;
        public int HighScore => highScore;

        private void OnEnable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Register<ScoreManager>(this);
            ServiceLocator.Current.Get<GameStateManager>().Register(this);
        }
        
        private void OnDisable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Unregister<ScoreManager>();
            ServiceLocator.Current.Get<GameStateManager>().Unregister(this);
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        
        public void AddScore()
        {
            score += 1;
            OnScoreChanged?.Invoke(score);
            if (score > highScore)
            {
                highScore = score;
                OnHighScoreChanged?.Invoke(highScore);
            }
        }
        
        public void ResetScore()
        {
            score = 0;
        }

        public void GameOver()
        {
            if (score > highScore)
            {
                highScore = score;
                OnHighScoreChanged?.Invoke(highScore);
            }
            score = 0;
            OnScoreChanged?.Invoke(score);
        }
    }
}