using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot_to_Kill {
  public interface IDrawable {
    void Draw(SpriteBatch spriteBatch);
  }
  class BackgroundMap : IDrawable {
    private Texture2D texture;
    public BackgroundMap(Texture2D texture) {
      this.texture = texture;
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);
    }
  }
  class DrawableTile : IDrawable {
    private Texture2D texture;
    private Vector2 position;
    private ITile tile;
    public DrawableTile(Texture2D texture, Vector2 vector2, ITile itile) {
      this.texture = texture;
      this.position = vector2;
      tile = itile;
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, position, Color.White);
    }
  }
}
