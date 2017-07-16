using System.Collections.Generic;

namespace Inputs
{
	public class KeyManager
	{
		private List<KeyHistory> keyHistories;

		public KeyManager()
		{
			keyHistories = new List<KeyHistory>();
		}

		public KeyHistoryId AddKeyHistory(KeyHistory keyHistory)
		{
			int count = keyHistories.Count;
			keyHistories.Add(keyHistory);
			return new KeyHistoryId(count);
		}

		internal KeyHistory GetKeyHistory(KeyHistoryId keyHistoryId)
		{
			int id = keyHistoryId.GetId();

			if (id < keyHistories.Count)
			{
				return keyHistories[id];
			}
			else
			{
				return null;
			}
		}
	}
}
