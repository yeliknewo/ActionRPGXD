using UnityEngine;

namespace Stats
{
	public class Stat
	{
		public Stat(float newCurrent, float newMax)
		{
			this.current = newCurrent;
			this.max = newMax;
		}

		[SerializeField]
		private float _current;

		public float current
		{
			get
			{
				return _current;
			}
			set
			{
				_current = value;
			}
		}

		[SerializeField]
		private float _max;

		public float max
		{
			get
			{
				return _max;
			}
			internal set
			{
				_max = value;
			}
		}
	}
}