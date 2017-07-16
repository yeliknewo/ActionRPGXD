using UnityEngine;

namespace Characters.Player
{
	public class PlayerAction
	{
		private PlayerActionType actionType;

		private WalkData walkData;

		public static PlayerAction MakePlayerWalkAction(float x, float y)
		{
			PlayerAction action = new PlayerAction(PlayerActionType.Walk);
			action.SetWalkData(WalkData.MakeWalkDataXY(x, y));

			return action;
		}

		private PlayerAction(PlayerActionType newActionType)
		{
			actionType = newActionType;
		}

		private void SetWalkData(WalkData newWalkData)
		{
			walkData = newWalkData;
		}

		internal WalkData GetWalkData()
		{
			return walkData;
		}

		internal PlayerActionType GetActionType()
		{
			return actionType;
		}
	}

	public enum PlayerActionType
	{
		Walk,
	}

	internal class WalkData
	{
		internal static WalkData MakeWalkDataXY(float x, float y)
		{
			WalkData walkData = new WalkData();
			walkData.SetXYDuo(x, y);
			return walkData;
		}

		private Vector2 xY;

		private void SetXYDuo(float x, float y)
		{
			SetXYVec(new Vector2(x, y));
		}

		private void SetXYVec(Vector2 newXY)
		{
			xY = newXY;
		}

		private void SetDirDegMag(float dirDeg, float mag)
		{
			SetXYVec(new Vector2(Mathf.Cos(dirDeg), Mathf.Sin(dirDeg)) * mag);
		}

		internal Vector2 GetXY()
		{
			return xY;
		}

		internal Vector2 GetDirDegMag()
		{
			return new Vector2(Mathf.Atan2(xY.y, xY.x), xY.magnitude);
		}
	}

}
