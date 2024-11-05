using Games.GameStateFramework;
using ModulerUISystem;
using ServiceLocatorFramework;

namespace Games.BouncyBall
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class StartScreen:MonoBehaviour
	{

		#region PRIVATE_VARS
		[SerializeField] private ViewConfig gamePlayViewConfig;
		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public void StartButtonClicked()
		{
			ServiceLocator.Current.Get<GameStateManager>().StartGame();
			ModulerUISystem.UIManager.instance.ShowView(gamePlayViewConfig);
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