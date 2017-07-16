using System;

namespace Inputs
{
	public class AxisHistory : KeyHistory
	{
		private float axisThresholdMin;
		private float axisThresholdMax;

		public AxisHistory(KeyStroke keyStroke, float offsetTime, float newAxisThresholdMin, float newAxisThresholdMax) : base(keyStroke, offsetTime)
		{
			axisThresholdMin = newAxisThresholdMin;
			axisThresholdMax = newAxisThresholdMax;
		}

		internal override void Update()
		{
			float axis = GetKeyStroke().GetAxis();

			if (axis >= axisThresholdMin && axis <= axisThresholdMax)
			{
				Press();
			}
		}

		public override float GetValue()
		{
			return GetKeyStroke().GetAxis();
		}

		public override bool IsX()
		{
			return GetKeyStroke().IsX();
		}

		public override bool IsY()
		{
			return GetKeyStroke().IsY();
		}
	}
}
