namespace Games.GameStateFramework
{
	using UnityEngine;
	using System;
	using System.Collections;

	public interface IGameTick : IGameState
	{
		void Tick();
	}
}