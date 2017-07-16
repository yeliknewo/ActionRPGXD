using System;
using Inputs.GPDXD;
using Moves;
using Stats;
using UnityEngine;

namespace Characters.Player
{
	public class Player : Character<StatType, PlayerAction>
	{
		private void Walk(Move<PlayerAction> move)
		{
			PlayerAction action = move.GetAction();

			WalkData walkData = action.GetWalkData();

			Vector2 mult = walkData.GetXY();

			Vector2 vals = move.GetAxisValues();

			vals.Scale(mult);

			SetMovement(vals);

			move.ActionDone();
		}

		private void SetMovement(Vector2 xY)
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.velocity = xY;
			rb.MoveRotation(Mathf.Atan2(xY.y, xY.x) * Mathf.Rad2Deg);
		}

		protected override void DoMove(Move<PlayerAction> move)
		{
			switch(move.GetAction().GetActionType())
			{
				case PlayerActionType.Walk:
					Walk(move);
					break;
			}
		}
	}
}