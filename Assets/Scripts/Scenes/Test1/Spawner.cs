using Characters.Player;
using Inputs;
using UnityEngine;

namespace Scenes.Test1
{
	public class Spawner : MonoBehaviour
	{
		private void Start()
		{
			KeyManager manager = new KeyManager();

			GameObject playerObj = PlayerBuilder.Get().Build(InputType.GPDXD, manager);
			playerObj.transform.position = Vector3.left;
		}
	}
}
