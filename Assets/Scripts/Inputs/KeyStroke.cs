using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
	public class KeyStroke
	{
		private KeyHandler keyHandler;

		private bool flagButton;

		private bool flagInvertAxis;

		private bool flagX;

		private bool flagY;

		private string inputName;

		public KeyStroke(KeyHandler newKeyHandler)
		{
			keyHandler = newKeyHandler;
			flagButton = keyHandler.IsButton();
			if (!flagButton)
			{
				flagInvertAxis = keyHandler.IsInvertAxis();
				flagX = keyHandler.IsX();
				flagY = keyHandler.IsY();
			}
			inputName = keyHandler.GetInputName();
		}

		public bool IsButton()
		{
			return flagButton;
		}

		public bool GetButtonDown()
		{
			if (flagButton)
			{
				return Input.GetButtonDown(inputName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButtonDown", keyHandler));
				return false;
			}
		}

		internal bool IsY()
		{
			return flagY;
		}

		internal bool IsX()
		{
			return flagX;
		}

		public bool GetButtonUp()
		{
			if (flagButton)
			{
				return Input.GetButtonUp(inputName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButtonUp", keyHandler));
				return false;
			}
		}

		public bool GetButtonHeld()
		{
			if (flagButton)
			{
				return Input.GetButton(inputName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButton", keyHandler));
				return false;
			}
		}

		public float GetAxis()
		{
			if (flagButton)
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was a button in GetAxis", keyHandler));
			}
			if (flagInvertAxis)
			{
				return -Input.GetAxis(inputName);
			}
			else
			{
				return Input.GetAxis(inputName);
			}
		}
	}
}
