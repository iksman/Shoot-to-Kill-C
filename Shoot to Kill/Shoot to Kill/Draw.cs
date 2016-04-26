using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Shoot_to_Kill {
  public interface IDrawable {
    void Draw(SpriteBatch spriteBatch);
  }
  class BackgroundMap : IDrawable {
    private Texture2D texture;
		public Vector2 pos;
    public BackgroundMap(Texture2D texture, GraphicsDeviceManager graphics) {
			this.texture = texture;
			this.pos = Statics.getOffsetForMap(texture, graphics);
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, pos, Color.White);
    }
  }
  class DrawableTile : IDrawable {
    public Texture2D texture;
    public Vector2 position;
    public ITile tile;
    public DrawableTile(Texture2D texture, Vector2 vector2, ITile itile) {
      this.texture = texture;
      this.position = vector2;
      tile = itile;
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, position, Color.White);
    }
  }

  class SideTracker {
    private List<Texture2D> textureList = new List<Texture2D>();
    private Texture2D texture;
    private Vector2 position;
    private int character, currentTexture;
    private ContentManager content;
    private GraphicsDeviceManager graphics;
    public SideTracker (ContentManager content, GraphicsDeviceManager graphics, int character, List<Character> list) {
      this.character = character;
      currentTexture = 0;
      this.content = content;
      this.graphics = graphics;
      textureList.Add(content.Load<Texture2D>("personbanner0_0.png"));
      textureList.Add(content.Load<Texture2D>("personbanner1_0.png"));
      textureList.Add(content.Load<Texture2D>("personbanner2_0.png"));
      textureList.Add(content.Load<Texture2D>("personbanner0_1.png"));
      this.texture = textureList[currentTexture];
      double posx = graphics.PreferredBackBufferWidth - texture.Width - 100;
      double posy = Statics.GetCenter(texture, graphics).Y - 150 + ((texture.Height - 1) * character);
      position = new Vector2((float) posx, (float) posy);
    }

    public void Update(List<Character> players) {
      Character tempchar = players[character];
      if (tempchar.firstcoin ^ tempchar.secondcoin) {
        if (currentTexture != 1) {
          currentTexture = 1;
          texture = textureList[currentTexture];
        }
      }else if (tempchar.firstcoin && tempchar.secondcoin) {
        if (currentTexture != 2) {
          currentTexture = 2;
          texture = textureList[currentTexture];
        }
      }else if (tempchar.gun) {
        if (currentTexture != 3) {
          currentTexture = 3;
          texture = textureList[currentTexture];
        }
      }else {
        if (currentTexture != 0) {
          currentTexture = 0;
          texture = textureList[currentTexture];
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch, List<Character> players) {
      spriteBatch.Draw(texture, position);
      var posx = position.X + 12.5;
      var posy = position.Y + 12.5;
      spriteBatch.Draw(players[character].texture, new Vector2((float)posx, (float)posy));
    }
  }
  class RollButton {
    private Texture2D texture;
    public Vector2 pos;
    private GraphicsDeviceManager graphics;
    public RollButton(GraphicsDeviceManager graphics, Texture2D texture) {
      this.graphics = graphics;
      this.texture = texture;
      var posx = graphics.PreferredBackBufferWidth - texture.Width - 150;
      var posy = Statics.GetCenter(texture, graphics).Y - 250;
      pos = new Vector2((float)posx, (float)posy);
    }
    public bool isClicked(MouseState oldMouseState, MouseState mouseState) {
      Rectangle rect = new Rectangle((int) pos.X ,(int) pos.Y, texture.Width, texture.Height);
      if(rect.Contains(mouseState.Position) && oldMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed) {
        return true;
      }else {
        return false;
      }
    }

    public void Update(Texture2D texture) {
      this.texture = texture;
    }

    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, pos, Color.White);
    }
  }

  class CurrentPlayerTurn {
    private Texture2D texture;
    private Vector2 pos;
    public CurrentPlayerTurn(Texture2D texture, RollButton rollButton) {
      this.texture = texture;
      var posx = rollButton.pos.X + 12.5;
      var posy = rollButton.pos.Y + 12.5;
      pos = new Vector2((float)posx, (float)posy);
    }
    public void Update(Texture2D texture) {
      this.texture = texture;
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, pos, Color.White);
    }
  }

  class DiceRoll {
    private Texture2D texture;
    private List<Texture2D> textureList = new List<Texture2D>();
    private Vector2 pos;
    public DiceRoll(ContentManager content, RollButton rollButton) {
      for (int i = 0; i < 7; i++) {
        textureList.Add(content.Load<Texture2D>("dice" + i.ToString() + ".png"));
      }
      texture = textureList[0];
      var posx = rollButton.pos.X + 225;
      var posy = rollButton.pos.Y;
      pos = new Vector2((float)posx, (float)posy);
    }
    public void Update(int step) {
      this.texture = textureList[step];
    }
    public void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(texture, pos, Color.White);
    }
  }


}
