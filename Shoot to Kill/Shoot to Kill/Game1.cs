using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Shoot_to_Kill {
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game {
		GraphicsDeviceManager graphics;
		KeyboardState newKeyboardState = Keyboard.GetState();
		MouseState mouseState, oldMouseState;
		SpriteBatch spriteBatch;
		BackgroundMap map;
		public static int tileoffsetx, tileoffsety, tilesx, tilesy;
		//List<ITile> tileList;
		List<Tuple<ITile, Vector2>> completeList;
		List<DrawableTile> drawableTiles = new List<DrawableTile>();
		List<Character> players = new List<Character>();
		int playerOnTurn = 0;
		public Game1(int width, int height, bool fullscreen) {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";



			graphics.PreferredBackBufferWidth = width;
			graphics.PreferredBackBufferHeight = height;
			graphics.IsFullScreen = fullscreen;
		}

		protected override void Initialize() {
			this.IsMouseVisible = true;
			base.Initialize();
		}

    protected override void LoadContent() {
			mouseState = new MouseState();
      spriteBatch = new SpriteBatch(GraphicsDevice);
      map = new BackgroundMap(Content.Load<Texture2D>("0.png"), graphics);
			tileoffsetx = 50;
			tileoffsety = 50;
			tilesx = 17;
			tilesy = 17;
			completeList = Statics.convertTiles(tileoffsetx, tileoffsety, Tiles.construct(0), tilesx, tilesy, map);
			foreach (Tuple<ITile, Vector2> tile in completeList) {
        drawableTiles.Add(new DrawableTile(Content.Load<Texture2D>("border.png"), tile.Item2, tile.Item1));
				//Console.WriteLine(tile.Item1.type());
			}
			players.Add(new Character(0, drawableTiles, Content.Load<Texture2D>("char1.png"), tilesx, tilesy));
			players.Add(new Character(0, drawableTiles, Content.Load<Texture2D>("char2.png"), tilesx, tilesy));
			players[0].setSteps(5);
		}

    protected override void UnloadContent() {
      // TODO: Unload any non ContentManager content here
    }

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			//oldKeyboardState = newKeyboardState;
			//newKeyboardState = Keyboard.GetState();
			oldMouseState = mouseState;
			mouseState = Mouse.GetState();
			spriteBatch.Begin();
			GraphicsDevice.Clear(Color.Gray);
			map.Draw(spriteBatch);
			//Statics.debugTiles(oldKeyboardState, newKeyboardState, spriteBatch, players);
			//Statics.debugSpecificChar(oldKeyboardState, newKeyboardState, spriteBatch, players[playerOnTurn], players);

			//foreach (Character character in players) {
			//	character.DrawBorders(spriteBatch, Statics.getOtherPositions(players, character));
			//}
			players[playerOnTurn].DrawBorders(spriteBatch, Statics.getOtherPositions(players, players[playerOnTurn]));
			if (players[playerOnTurn].stepsleft > 0) {
				//players[playerOnTurn].Update(spriteBatch, Statics.getOtherPositions(players, players[playerOnTurn]));
				//players[playerOnTurn].DrawBorders(spriteBatch, Statics.getOtherPositions(players, players[playerOnTurn]));
				players[playerOnTurn].Update(oldMouseState, mouseState, Statics.getOtherPositions(players, players[playerOnTurn]));
				//Statics.debugSpecificChar(oldKeyboardState, newKeyboardState, spriteBatch, players[playerOnTurn], players);
			}	else {
				playerOnTurn++;
				if (playerOnTurn == players.Count) {
					playerOnTurn = 0;
					
				}
				players[playerOnTurn].setSteps(new Random().Next(1, 6));
				players[playerOnTurn].setOldPos();
			}

			//Console.WriteLine(players[playerOnTurn].stepsleft);
			base.Update(gameTime);
			spriteBatch.End();
		}

    protected override void Draw(GameTime gameTime) {
			List<int> tiles = new List<int>();
			spriteBatch.Begin();
      
      //foreach (DrawableTile tile in drawableTiles) {
      //  tile.Draw(spriteBatch);
      //}
			foreach (Character character in players) {
				character.Draw(spriteBatch, Statics.checkAmountResults(tiles,character.currentPos()));
				tiles.Add(character.currentPos());
			}
      spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
