using UnityEngine;
using Inputs;

namespace Characters
{
	public abstract class CharacterBuilder<T> where T: CharacterBuilder<T>
	{
		private GameObject obj;

		public GameObject Build(InputType inputType, KeyManager manager)
		{
			obj = new GameObject(GetName());
			AddCore().AddRenderer().AddRigidbody().AddCollider().AddStats().AddMoves(inputType, manager);
			return obj;
		}

		protected GameObject GetObj()
		{
			return obj;
		}

		protected abstract string GetName();
		protected abstract Sprite GetSprite();
		protected abstract T AddCore();
		protected abstract T AddRenderer();
		protected abstract T AddRigidbody();
		protected abstract T AddCollider();
		protected abstract T AddStats();
		protected abstract T AddMoves(InputType inputType, KeyManager manager);
	}
}

