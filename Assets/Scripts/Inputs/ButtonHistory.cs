using System;

namespace Inputs
{
	public class ButtonHistory : KeyHistory
	{
		private ButtonEventType buttonEventType;

		public ButtonHistory(ButtonEventType newButtonEventType, KeyStroke newKeyStroke, float newOffsetTime) : base(newKeyStroke, newOffsetTime)
		{
			buttonEventType = newButtonEventType;
		}

		public override float GetValue()
		{
			return IsActive() ? 1f : 0f;
		}

		public override bool IsX()
		{
			return false;
		}

		public override bool IsY()
		{
			return false;
		}

		internal override void Update()
		{
			switch (buttonEventType)
			{
				case ButtonEventType.ButtonDown:
					if (GetKeyStroke().GetButtonDown())
					{
						Press();
					}
					break;

				case ButtonEventType.ButtonHeld:
					if (GetKeyStroke().GetButtonHeld())
					{
						Press();
					}
					break;

				case ButtonEventType.ButtonUp:
					if (GetKeyStroke().GetButtonUp())
					{
						Press();
					}
					break;
			}
		}
	}
}