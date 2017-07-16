using Inputs;
using UnityEngine;

namespace Moves
{
	public class Move<A>
	{
		private KeyCombo combo;

		private A action;

		private int priority;

		public Move(KeyCombo newCombo, A newAction, int newPriority)
		{
			combo = newCombo;
			action = newAction;
			priority = newPriority;
		}

		public Vector2 GetAxisValues()
		{
			return combo.GetAxisValues();
		}

		public bool IsActive()
		{
			return combo.IsComboTriggered();
		}

		public void Update()
		{
			combo.Update();
		}

		public void ActionDone()
		{
			combo.SetComboDone();
		}

		public A GetAction()
		{
			return action;
		}

		internal int GetPriority()
		{
			return priority;
		}
	}
}
