using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot_to_Kill {
  class Statics {
    public static Vector2 getCenter(GraphicsDeviceManager graphics, Texture2D mapimg) {
      int a = (graphics.PreferredBackBufferWidth / 2) - (mapimg.Width / 2);
      int b = (graphics.PreferredBackBufferHeight / 2) - (mapimg.Height / 2);
      return new Vector2(a, b);
    }

		public static Vector2 GetCenter(Texture2D mapimg, GraphicsDeviceManager graphics)//Method for deciding the middle of something -> will give back the coordinate to use, so that an image will be centerred
		{
			int a = (graphics.PreferredBackBufferWidth / 2) - (mapimg.Width / 2);
			int b = (graphics.PreferredBackBufferHeight / 2) - (mapimg.Height / 2);
			return new Vector2(a, b);
		}

		public static Vector2 getOffsetForMap (Texture2D texture, GraphicsDeviceManager graphics) {
			var offset = (graphics.PreferredBackBufferHeight - texture.Height) / 2;
			return new Vector2(offset, offset);
		}

		public static Tuple<ITile, Vector2> postuple (ITile itile, Vector2 vector2) {
      return new Tuple<ITile, Vector2>(itile, vector2);
    }

    public static List<Tuple<ITile,Vector2>> convertTiles (int offsetx, int offsety, List<ITile> tilelist, int tilesx, int tilesy, BackgroundMap background) {
      List<Tuple<ITile, Vector2>> list = new List<Tuple<ITile, Vector2>>();
			var begin = background.pos;
      int counter = 0;
      for (int y = 0; y < tilesy; y++) {
        for (int x = 0; x < tilesx; x++) {
          if (x == 0) {
            if (y == 0) {
              list.Add(postuple(tilelist[counter], new Vector2(begin.X, begin.Y)));
              counter++;
            }else {
              list.Add(postuple(tilelist[counter], new Vector2(begin.X, (begin.Y + (y * offsety)))));
              counter++;
            }
          }else{
            list.Add(postuple(tilelist[counter], new Vector2((begin.X + (x * offsetx)), (begin.Y + (y * offsety)))));
            counter++;
          }
              
        }
      }
      return list;
    }

		public static int checkAmountResults (List<int> list, int search) {
			int i = 0;
			foreach (int item in list) {
				if (item == search) {
					i++;
				}
			}
			return i;
		}

		public static void debugTiles(KeyboardState oldKeyboardState, KeyboardState newKeyboardState, SpriteBatch spriteBatch, List<Character> players) {
			if (oldKeyboardState.IsKeyUp(Keys.Enter) == true && newKeyboardState.IsKeyDown(Keys.Enter) == true) {
				foreach (Character character in players) {
					character.setPos(1);
					character.Update(spriteBatch);
				}
			}

			if (oldKeyboardState.IsKeyUp(Keys.RightShift) == true && newKeyboardState.IsKeyDown(Keys.RightShift) == true) {
				foreach (Character character in players) {
					character.setPos(-1);
					character.Update(spriteBatch);
				}
			}
		}

		public static void debugSpecificChar(KeyboardState oldKeyboardState, KeyboardState newKeyboardState, SpriteBatch spriteBatch, Character character) {
			if (oldKeyboardState.IsKeyUp(Keys.Enter) == true && newKeyboardState.IsKeyDown(Keys.Enter) == true) {
				character.setPos(1);
				character.Update(spriteBatch);
			}

			if (oldKeyboardState.IsKeyUp(Keys.RightShift) == true && newKeyboardState.IsKeyDown(Keys.RightShift) == true) {
				character.setPos(-1);
				character.Update(spriteBatch);
			}
		}
	}
}