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
		KeyboardState oldKeyboardState;
		KeyboardState newKeyboardState = Keyboard.GetState();
    SpriteBatch spriteBatch;
    BackgroundMap map;
    //List<ITile> tileList;
    List<Tuple<ITile,Vector2>> completeList;
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
      spriteBatch = new SpriteBatch(GraphicsDevice);
      map = new BackgroundMap(Content.Load<Texture2D>("0.png"), graphics);
			completeList = Statics.convertTiles(50, 50, Tiles.construct(0), 17, 17, map);
			foreach (Tuple<ITile, Vector2> tile in completeList) {
        drawableTiles.Add(new DrawableTile(Content.Load<Texture2D>("border.png"), tile.Item2, tile.Item1));
				//Console.WriteLine(tile.Item1.type());
			}
			players.Add(new Character(0, drawableTiles, Content.Load<Texture2D>("char1.png"), 17, 17));
			players.Add(new Character(0, drawableTiles, Content.Load<Texture2D>("char2.png"), 17, 17));
		}

    protected override void UnloadContent() {
      // TODO: Unload any non ContentManager content here
    }

    protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			oldKeyboardState = newKeyboardState;
			newKeyboardState = Keyboard.GetState();
			spriteBatch.Begin(); GraphicsDevice.Clear(Color.Gray); map.Draw(spriteBatch); spriteBatch.End();
			if (oldKeyboardState.IsKeyUp(Keys.Space) == true && newKeyboardState.IsKeyDown(Keys.Space) == true) {
				playerOnTurn++;
				if (playerOnTurn == players.Count) {
					playerOnTurn = 0;
				}
			}

			//Statics.debugTiles(oldKeyboardState, newKeyboardState, spriteBatch, players);
			Statics.debugSpecificChar(oldKeyboardState, newKeyboardState, spriteBatch, players[playerOnTurn]);
			foreach (Character character in players) {
				character.Update(spriteBatch);
			}
			base.Update(gameTime);
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
