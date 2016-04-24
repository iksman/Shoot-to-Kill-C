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

    public static Tuple<ITile, Vector2> postuple (ITile itile, Vector2 vector2) {
      return new Tuple<ITile, Vector2>(itile, vector2);
    }

    public static List<Tuple<ITile,Vector2>> convertTiles (int offsetx, int offsety, List<ITile> tilelist, int tilesx, int tilesy) {
      List<Tuple<ITile, Vector2>> list = new List<Tuple<ITile, Vector2>>();
      int counter = 0;
      for (int y = 0; y < 17; y++) {
        for (int x = 0; x < 17; x++) {
          if (x == 0) {
            if (y == 0) {
              list.Add(postuple(tilelist[counter], new Vector2(0, 0)));
              counter++;
            }else {
              list.Add(postuple(tilelist[counter], new Vector2(0, (y * offsety) + 1)));
              counter++;
            }
          }else{
            list.Add(postuple(tilelist[counter], new Vector2((x * offsetx) + 1, (y * offsety) + 1)));
          }
        }
      }
      return list;
    }
  }
}