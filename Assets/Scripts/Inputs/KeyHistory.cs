using UnityEngine;

namespace Inputs
{
	public abstract class KeyHistory
	{
		private KeyStroke keyStroke;
		private float lastPressTime;
		private float offsetTime;
		private float nextPressThreshold;

		public KeyHistory(KeyStroke newKeyStroke, float newOffsetTime)
		{
			keyStroke = newKeyStroke;
			offsetTime = newOffsetTime;
			nextPressThreshold = Time.time - 1;
		}

		internal bool IsActive()
		{
			return nextPressThreshold >= Time.time;
		}

		internal abstract void Update();

		protected KeyStroke GetKeyStroke()
		{
			return keyStroke;
		}

		protected void Press()
		{
			lastPressTime = Time.time;
			nextPressThreshold = lastPressTime + offsetTime;
		}

		public abstract float GetValue();

		public abstract bool IsX();
		public abstract bool IsY();
	}
}
