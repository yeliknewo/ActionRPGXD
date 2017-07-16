using UnityEngine;
using System.Collections.Generic;

namespace Inputs
{
	public class KeyCombo
	{
		private KeyManager keyManager;
		private List<KeyHistory> keyHistories;

		private int keyHistoryCurrent;
		private bool comboReady;
		private bool comboDone;

		public KeyCombo(KeyManager newKeyManager)
		{
			keyManager = newKeyManager;
			keyHistories = new List<KeyHistory>();
			comboReady = false;
			comboDone = true;
		}

		public Vector2 GetAxisValues()
		{
			float x = float.NaN;
			float y = float.NaN;
			foreach (KeyHistory key in keyHistories)
			{
				if (key.IsX() && float.IsNaN(x))
				{
					x = key.GetValue();
				}

				if (key.IsY() && float.IsNaN(y))
				{
					y = key.GetValue();
				}
			}
			if (float.IsNaN(x))
			{
				x = 0f;
			}
			if (float.IsNaN(y))
			{
				y = 0f;
			}
			return new Vector2(x, y);
		}

		public void RegisterKeyHistory(KeyHistoryId keyHistoryId)
		{
			keyHistories.Add(keyManager.GetKeyHistory(keyHistoryId));
		}

		public void Update()
		{
			comboReady = false;

			foreach (KeyHistory keyHistory in keyHistories)
			{
				keyHistory.Update();
			}

			if (comboDone)
			{
				KeyHistory keyHistory = keyHistories[keyHistoryCurrent];

				if (keyHistory.IsActive())
				{
					keyHistoryCurrent++;
					if (keyHistoryCurrent == keyHistories.Count)
					{
						keyHistoryCurrent = 0;
						comboReady = true;
						comboDone = false;
					}
				}
			}
		}

		public bool IsComboTriggered()
		{
			return comboReady;
		}

		public void SetComboDone()
		{
			comboDone = true;
		}
	}











}