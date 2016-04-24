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
    SpriteBatch spriteBatch;
    BackgroundMap map;
    //List<ITile> tileList;
    List<Tuple<ITile,Vector2>> completeList;
    List<DrawableTile> drawableTiles = new List<DrawableTile>();
    public Game1(int width, int height, bool fullscreen) {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      completeList = Statics.convertTiles(50, 50, Tiles.construct(0), 17, 17);
      
      
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
      map = new BackgroundMap(Content.Load<Texture2D>("0.png"));
      foreach (Tuple<ITile, Vector2> tile in completeList) {
        drawableTiles.Add(new DrawableTile(Content.Load<Texture2D>(tile.Item1.type() + ".png"), tile.Item2, tile.Item1));
        //Console.WriteLine(tile.Item1.type());
      }
    }

    protected override void UnloadContent() {
      // TODO: Unload any non ContentManager content here
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
      GraphicsDevice.Clear(Color.CornflowerBlue);
      spriteBatch.Begin();
      map.Draw(spriteBatch);
      foreach (DrawableTile tile in drawableTiles) {
        tile.Draw(spriteBatch);
      }
      spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
