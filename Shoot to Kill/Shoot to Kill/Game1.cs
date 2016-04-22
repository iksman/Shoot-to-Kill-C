using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Shoot_to_Kill {
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    List<ITile> tileList;

    public Game1(int width, int height, bool fullscreen) {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      tileList = Tiles.construct(0);
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

      spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
