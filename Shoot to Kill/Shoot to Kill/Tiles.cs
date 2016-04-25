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
		class PenetratableTile : ITile { // Is naturally untraverseable
			public PenetratableTile() {
			}
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
				return "penetrate";
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
    class GunTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public GunTile(bool up, bool down, bool left, bool right) {
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
        return "gun";
      }
    }
    class TruckTile : ITile {
      private bool down;
      private bool up;
      private bool left;
      private bool right;
      public TruckTile(bool up, bool down, bool left, bool right) {
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
        return "truck";
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

    private static NormalTile getAllNormal() {
      return new NormalTile(true, true, true, true);
    }
    private static BushTile getAllBush() {
      return new BushTile(true, true, true, true);
    }
    private static CoinTile getAllCoin() {
      return new CoinTile(true, true, true, true);
    }
    private static CustomTile getAllCustom(string type) {
      return new CustomTile(true, true, true, true, type);
    }
    private static GunTile getAllGun() {
      return new GunTile(true, true, true, true);
    }
    private static HighwayTile getAllHighway() {
      return new HighwayTile(true, true, true, true);
    }


    public static List<ITile> construct(int map){
      List<ITile> tileList = new List<ITile>();
      tileList.Clear();
      int oldCount = 0;
      if (map == 0) {
        //Line 1
        Console.WriteLine(tileList.Count());
        tileList.Add(new NormalTile(false, true, false, true));
        for (int i = 0; i < 15; i++) {
          tileList.Add(new NormalTile(false, true, true, true));
          
        }
        tileList.Add(new NormalTile(false, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 2
        tileList.Add(new NormalTile(false, true, false, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllBush());
        }
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllNormal());
        }
				tileList.Add(new NormalTile(true, false, true, true));
				for (int i = 0; i < 5; i++) {
					tileList.Add(getAllNormal());
				}
				tileList.Add(getAllCoin());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 3
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllBush());
        }
        tileList.Add(new BushTile(true, false, true, true));
        tileList.Add(new BushTile(true, false, true, true));
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 5; i++) {
          tileList.Add(getAllNormal());
        }
				tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 4
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllBush());
        tileList.Add(getAllBush());
        tileList.Add(new BushTile(true, true, true, false));
        tileList.Add(new GunTile(false, false, false, true));
        tileList.Add(new TruckTile(false, false, true, true));
        tileList.Add(new TruckTile(false, true, true, false));
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllBush());
        }
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 5
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllBush());
        }
        tileList.Add(new BushTile(false, true, true, true));
        tileList.Add(new BushTile(false, true, true, true));
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(getAllNormal());
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllBush());
        }
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 6
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllNormal());
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllBush());
        }
        for (int i = 0; i < 6; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(new NormalTile(true, false, true, true));
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 7
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 9; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new UntraverseableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 8
        tileList.Add(new NormalTile(true, false, false, true));
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        for (int i = 0; i < 4; i++) {
          tileList.Add(new NormalTile(true, false, true, true));
        }
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(new NormalTile(false, false, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(new NormalTile(true, false, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 9
        tileList.Add(new HighwayTile(false, true, false, true));
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(getAllHighway());
        tileList.Add(getAllHighway());
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(new HighwayTile(false, false, true, true));
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(new HighwayTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new UntraverseableTile());
        tileList.Add(new HighwayTile(true, true, false, true));
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(getAllHighway());
        tileList.Add(getAllHighway());
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(new HighwayTile(false, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        //Line 10
        tileList.Add(new HighwayTile(true, true, false, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllHighway());
        }
        tileList.Add(new HighwayTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new HighwayTile(true, true, false, true));
        tileList.Add(getAllHighway());
        tileList.Add(new HighwayTile(false, true, true, true));
        tileList.Add(new HighwayTile(false, true, true, true));
        for (int i = 0; i < 5; i++) {
          tileList.Add(getAllHighway());
        }
        tileList.Add(new HighwayTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 11
        tileList.Add(new HighwayTile(true, false, false, true));
        tileList.Add(new HighwayTile(true, false, true, true));
        tileList.Add(new HighwayTile(true, false, true, true));
        tileList.Add(getAllHighway());
        tileList.Add(getAllHighway());
        tileList.Add(new HighwayTile(true, false, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new HighwayTile(true, false, false, true));
        tileList.Add(new HighwayTile(true, false, true, true));
        for (int i = 0; i < 3; i++) {
          tileList.Add(getAllHighway());
        }
        for (int i = 0; i < 4; i++) {
          tileList.Add(new HighwayTile(true, false, true, true));
        }
        tileList.Add(new HighwayTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 12
        tileList.Add(new NormalTile(false, true, false, true));
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        for (int i = 0; i < 4; i++) {
          tileList.Add(new NormalTile(false, true, true, true));
        }
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(new NormalTile(true,false,true,true));
        
        for (int i = 0; i < 4; i++) {
          tileList.Add(new NormalTile(false, true, true, true));
        }
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 13
        tileList.Add(new NormalTile(true, true, false, false));
        tileList.Add(new PenetratableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(new NormalTile(true, false, true, true));
        for (int i = 0; i < 5; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new TruckTile(false, true, false, true));
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, false, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 14
        tileList.Add(new BushTile(true, true, false, false));
        tileList.Add(new PenetratableTile());
        tileList.Add(new NormalTile(true, true, false, false));
        tileList.Add(new PenetratableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new TruckTile(true, true, false, false));
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 15
        tileList.Add(new BushTile(true, true, false, true));
        tileList.Add(new BushTile(false,true,true,true));
        tileList.Add(new BushTile(true, true, true, false));
        tileList.Add(new PenetratableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(new BushTile(true, true, true, false));
        tileList.Add(new GunTile(true, false, false, false));
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(new NormalTile(true, true, true, false));
        tileList.Add(new UntraverseableTile());
        tileList.Add(new NormalTile(true, true, false, true));
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 16
        tileList.Add(new BushTile(true, true, false, true));
        tileList.Add(getAllCoin());
        tileList.Add(getAllBush());
        tileList.Add(new NormalTile(false, false, true, true));
        tileList.Add(new NormalTile(true, false, true, true));
        for (int i = 0; i < 4; i++) {
          tileList.Add(getAllNormal());
        }
        tileList.Add(getAllBush());
        tileList.Add(new BushTile(false, true, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(false, true, true, true));
        tileList.Add(getAllNormal());
        tileList.Add(getAllNormal());
        tileList.Add(new NormalTile(true, true, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
        // Line 17
        tileList.Add(new BushTile(true, false, false, true));
        tileList.Add(new BushTile(true, false, true, true));
        tileList.Add(new BushTile(true, false, true, false));
        tileList.Add(new PenetratableTile());
        tileList.Add(new PenetratableTile());
        tileList.Add(new NormalTile(true, false, false, true));
        for (int i = 0; i < 10; i++) {
          tileList.Add(new NormalTile(true, false, true, true));
        }
        tileList.Add(new NormalTile(true, false, true, false));
        Console.WriteLine("1: " + (tileList.Count() - oldCount).ToString());
        oldCount = tileList.Count();
      }
      return tileList;
    }
  }
}
