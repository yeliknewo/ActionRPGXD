using System.Collections.Generic;
using UnityEngine;
using Stats;
using Moves;

namespace Characters
{
	public abstract class Character<S, A> : MonoBehaviour
	{
		private Dictionary<S, Stat> stats;

		private List<Move<A>> moves;

		internal void InitMoves()
		{
			moves = new List<Move<A>>();
		}

		internal void AddMove(Move<A> move)
		{
			moves.Add(move);
		}

		private void Update()
		{
			Move<A> activeMove = null;

			foreach (Move<A> move in moves)
			{
				move.Update();
				if (move.IsActive() && ((activeMove != null && move.GetPriority() > activeMove.GetPriority()) || activeMove == null))
				{
					activeMove = move;
				}
			}

			if (activeMove != null)
			{
				DoMove(activeMove);
			}
		}

		protected abstract void DoMove(Move<A> move);

		internal void InitStats()
		{
			stats = new Dictionary<S, Stat>();
		}

		public Stat GetStat(S statType)
		{
			Stat stat;
			stats.TryGetValue(statType, out stat);
			return stat;
		}

		internal void SetBaseStat(S statType, Stat stat)
		{
			if (!stats.ContainsKey(statType))
			{
				stats.Add(statType, stat);
			}
			else
			{
				Debug.LogException(new System.Exception(string.Format("Stat ({0}) was already in stats for ({1})", statType, name)));
			}
		}
	}
}
