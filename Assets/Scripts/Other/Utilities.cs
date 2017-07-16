using UnityEngine;

namespace Other
{
	public class Utilities
	{
		public static Sprite LoadSprite(string path, string errorMessage)
		{
			Sprite sprite = Resources.Load<Sprite>(path);
			Debug.Assert(sprite != null, errorMessage);
			return sprite;
		}
	}
}