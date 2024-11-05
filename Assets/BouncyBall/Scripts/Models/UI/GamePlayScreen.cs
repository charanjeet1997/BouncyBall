using TMPro;

namespace Games.BouncyBall
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class GamePlayScreen:MonoBehaviour
	{

		#region PRIVATE_VARS
		[SerializeField] private TMP_Text scoreText;
		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		private void OnEnable()
		{
			ScoreManager.OnScoreChanged += OnUpdatePoints;
		}
		
		private void OnDisable()
		{
			ScoreManager.OnScoreChanged -= OnUpdatePoints;
		}

		#endregion

		#region PUBLIC_METHODS
	
		#endregion

		#region PRIVATE_METHODS
		private void OnUpdatePoints(int points)
		{
			scoreText.text = points.ToString();
		}
		#endregion

	}
}