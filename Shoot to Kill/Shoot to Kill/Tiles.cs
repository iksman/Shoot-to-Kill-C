using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoot_to_Kill {
  public interface ITile {
    bool canUp();
    bool canDown();
    bool canLeft();
    bool canRight();
    string type();
  }
  class Tiles {
    class NormalTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public NormalTile(bool up, bool down, bool left, bool right) {
        this.down = down;
        this.up = up;
        this.left = left;
        this.right = right;
      }
      public bool canDown() {
        return down;
      }
      public bool canLeft() {
        return left;
      }
      public bool canRight() {
        return right;
      }
      public bool canUp() {
        return up;
      }
      public string type() {
        return "normal";
      }
    }
    class HighwayTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public HighwayTile(bool up, bool down, bool left, bool right) {
        this.down = down;
        this.up = up;
        this.left = left;
        this.right = right;
      }
      public bool canDown() {
        return down;
      }
      public bool canLeft() {
        return left;
      }
      public bool canRight() {
        return right;
      }
      public bool canUp() {
        return up;
      }
      public string type() {
        return "highway";
      }
    }
    class BushTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public BushTile(bool up, bool down, bool left, bool right) {
        this.down = down;
        this.up = up;
        this.left = left;
        this.right = right;
      }
      public bool canDown() {
        return down;
      }
      public bool canLeft() {
        return left;
      }
      public bool canRight() {
        return right;
      }
      public bool canUp() {
        return up;
      }
      public string type() {
        return "bush";
      }
    }
    class UntraverseableTile : ITile {
      public bool canDown() {
        return false;
      }
      public bool canLeft() {
        return false;
      }
      public bool canRight() {
        return false;
      }
      public bool canUp() {
        return false;
      }
      public string type() {
        return "untravers";
      }
    }
    class CoinTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public CoinTile(bool up, bool down, bool left, bool right) {
        this.down = down;
        this.up = up;
        this.left = left;
        this.right = right;
      }
      public bool canDown() {
        return down;
      }
      public bool canLeft() {
        return left;
      }
      public bool canRight() {
        return right;
      }
      public bool canUp() {
        return up;
      }
      public string type() {
        return "coin";
      }
    }
    class CustomTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      private string _type;
      public CustomTile(bool up, bool down, bool left, bool right, string type) {
        this.down = down;
        this.up = up;
        this.left = left;
        this.right = right;
        this._type = type;
      }
      public bool canDown() {
        return down;
      }
      public bool canLeft() {
        return left;
      }
      public bool canRight() {
        return right;
      }
      public bool canUp() {
        return up;
      }
      public string type() {
        return _type;
      }
    }
    public static List<ITile> construct(){
      List<ITile> tileList = new List<ITile>();
      //Line 1
      tileList.Add(new NormalTile(false, true, false, true));
      for (int i = 0; i < 16; i++) {
        tileList.Add(new NormalTile(false, true, true, true));
      }
      tileList.Add(new NormalTile(false, true, true, false));

      //Line 2
      tileList.Add(new NormalTile(false, true, false, true));
      for (int i = 0; i < 5; i++) {
        tileList.Add(new BushTile(true, true, true, true));
      }
      for (int i = 0; i < 11; i++) {
        tileList.Add(new NormalTile(true, true, true, true));
      }
      tileList.Add(new CoinTile(true,true,true,true));
      tileList.Add(new NormalTile(true, true, true, false));

      //Line 3
      tileList.Add(new NormalTile(true, true, false, true));
      for (int i = 0; i < 4; i++) {
        tileList.Add(new BushTile(true, true, true, true));
      }
      tileList.Add(new BushTile(true, false, true, true));
      tileList.Add(new BushTile(true, false, true, true));
      return tileList;
    }
  }
}
