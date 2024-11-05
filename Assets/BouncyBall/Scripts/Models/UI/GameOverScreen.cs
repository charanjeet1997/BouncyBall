using Games.GameStateFramework;
using ModulerUISystem;
using ServiceLocatorFramework;
using TMPro;

namespace Games.BouncyBall
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class GameOverScreen:MonoBehaviour
	{

		#region PRIVATE_VARS
		[SerializeField] private TMP_Text scoreText;
		[SerializeField] private TMP_Text highScoreText;
		[SerializeField] private ViewConfig gameplayViewConfig;
		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		
		public void OnShowAnimationStarted()
		{
			scoreText.text = ServiceLocator.Current.Get<ScoreManager>().Score.ToString();
			highScoreText.text = ServiceLocator.Current.Get<ScoreManager>().HighScore.ToString();
			// Show animation started logic here
		}
		public void RestartButtonClicked()
		{
			// Restart game logic here
			ServiceLocator.Current.Get<GameStateManager>().StartGame();
			ModulerUISystem.UIManager.instance.ShowView(gameplayViewConfig);
		}
		
		public void ExitButtonClicked()
		{
			Application.Quit();
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}