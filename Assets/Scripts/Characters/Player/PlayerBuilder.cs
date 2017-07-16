using System;
using Inputs;
using UnityEngine;
using Other;
using Moves;
using Inputs.GPDXD;

namespace Characters.Player
{
	public class PlayerBuilder : CharacterBuilder<PlayerBuilder>
	{
		private static PlayerBuilder playerBuilder;

		public static PlayerBuilder Get()
		{
			if(playerBuilder == null)
			{
				playerBuilder = new PlayerBuilder();
			}
			return playerBuilder;
		}

		protected override PlayerBuilder AddCore()
		{
			GetObj().AddComponent<Player>();

			return this;
		}

		protected override PlayerBuilder AddRenderer()
		{
			SpriteRenderer renderer = GetObj().AddComponent<SpriteRenderer>();
			renderer.sprite = GetSprite();

			return this;
		}

		protected override PlayerBuilder AddRigidbody()
		{
			Rigidbody2D rb = GetObj().AddComponent<Rigidbody2D>();

			rb.gravityScale = 0f;

			return this;
		}

		protected override PlayerBuilder AddCollider()
		{
			GetObj().AddComponent<CircleCollider2D>();

			return this;
		}

		protected override PlayerBuilder AddStats()
		{
			Player player = GetObj().GetComponent<Player>();
			player.InitStats();
			player.SetBaseStat(Stats.StatType.Health, new Stats.Stat(HEALTH_CURRENT_STARTING, HEALTH_MAX_STARTING));

			return this;
		}

		protected override PlayerBuilder AddMoves(InputType inputType, KeyManager manager)
		{
			Player player = GetObj().GetComponent<Player>();
			player.InitMoves();

			switch(inputType)
			{
				case InputType.GPDXD:
					AddMovesGPDXD(manager);
					break;
			}

			return this;
		}

		private void AddMovesGPDXD(KeyManager manager)
		{
			Player player = GetObj().GetComponent<Player>();

			KeyHistoryId leftX = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyX)), 0f, -1f, 1f));
			KeyHistoryId leftY = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyY)), 0f, -1f, 1f));

			{
				KeyCombo combo = new KeyCombo(manager);

				PlayerAction action = PlayerAction.MakePlayerWalkAction(1f, 1f);

				combo.RegisterKeyHistory(leftX);
				combo.RegisterKeyHistory(leftY);

				Move<PlayerAction> move = new Move<PlayerAction>(combo, action, PriorityConstants.PRIORITY_WALK);

				player.AddMove(move);
			}

			//KeyHistoryId leftLeft = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyX)), 0f, -1f, -0.1f));
			//KeyHistoryId leftRight = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyX)), 0f, 0.1f, 1f));
			//KeyHistoryId leftUp = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyY)), 0f, 0.1f, 1f));
			//KeyHistoryId leftDown = manager.AddKeyHistory(new AxisHistory(new KeyStroke(new GPDXDKeyHandler(GPDXDKeyType.LeftJoyY)), 0f, -1f, -0.1f));

			//{
			//	KeyCombo combo = new KeyCombo(manager);

			//	PlayerAction action = PlayerAction.MakePlayerWalkAction(1f, 1f);

			//	combo.RegisterKeyHistory(leftLeft);

			//	Move<PlayerAction> move = new Move<PlayerAction>(combo, action, PriorityConstants.PRIORITY_WALK_LEFT);

			//	player.AddMove(move);
			//}

			//{
			//	KeyCombo combo = new KeyCombo(manager);

			//	PlayerAction action = PlayerAction.MakePlayerWalkAction(1f, 1f);

			//	combo.RegisterKeyHistory(leftRight);

			//	Move<PlayerAction> move = new Move<PlayerAction>(combo, action, PriorityConstants.PRIORITY_WALK_RIGHT);

			//	player.AddMove(move);
			//}

			//{
			//	KeyCombo combo = new KeyCombo(manager);

			//	PlayerAction action = PlayerAction.MakePlayerWalkAction(1f, 1f);

			//	combo.RegisterKeyHistory(leftUp);

			//	Move<PlayerAction> move = new Move<PlayerAction>(combo, action, PriorityConstants.PRIORITY_WALK_UP);

			//	player.AddMove(move);
			//}

			//{
			//	KeyCombo combo = new KeyCombo(manager);

			//	PlayerAction action = PlayerAction.MakePlayerWalkAction(1f, 1f);

			//	combo.RegisterKeyHistory(leftDown);

			//	Move<PlayerAction> move = new Move<PlayerAction>(combo, action, PriorityConstants.PRIORITY_WALK_DOWN);

			//	player.AddMove(move);
			//}
		}

		protected override Sprite GetSprite()
		{
			return Utilities.LoadSprite(PATH_ASSET_SPRITE, "Unable to load Player sprite");
		}

		protected override string GetName()
		{
			return NAME;
		}

		private const string NAME = "Player";

		private const float HEALTH_CURRENT_STARTING = 10f;

		private const float HEALTH_MAX_STARTING = 10f;

		private const string PATH_ASSET_SPRITE = "Sprites\\Player";
	}
}