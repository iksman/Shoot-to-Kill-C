using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot_to_Kill {
	class Character {
		private Texture2D texture;
		private int pos;
		private List<DrawableTile> tileList;
		private int offsetx, offsety;
		public double stepsleft;
		private int oldposition;
		private bool firstcoin, secondcoin, gun;
		public Character(int startingpos, List<DrawableTile> tileList, Texture2D texture, int offsety, int offsetx) {
			this.texture = texture;
			this.pos = startingpos;
			setOldPos();
			this.tileList = tileList;
			this.offsety = offsety;
			this.offsetx = offsetx;
			this.firstcoin = false;
			this.secondcoin = false;
			this.gun = false;
		}
		public DrawableTile currentTile() {
			return tileList[pos];
		}
		public int currentPos() {
			return pos;
		}
		public void setPos(int offset) {
			pos += offset;
			if (pos == -1) {
				pos = (17 * 17) - 1;
			}else if (pos == (17 * 17)) {
				pos = 0;
			}
		}

		public void setSteps(int steps) {
			stepsleft = steps;
		}

		public void Draw(SpriteBatch spriteBatch, int offset) {
			var trueoffset = offset * 10;
			spriteBatch.Draw(texture, tileList[pos].position + new Vector2(trueoffset, 0), Color.White);
		}

		public void setOldPos() {
			oldposition = pos;
		}

		public void DrawBorders(SpriteBatch spriteBatch, List<int> otherPositions) {
			if (currentTile().tile.canLeft()) {
				if (otherPositions.Contains(pos - 1) != true) {
					if (stepsleft == 1 && (pos - 1) == oldposition) {
						//geen hond
					} else {
						tileList[pos - 1].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canRight()) {
				if (otherPositions.Contains(pos + 1) != true) {
					if (stepsleft == 1 && (pos + 1) == oldposition) {
						//geen hond
					}	else {
						tileList[pos + 1].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canUp()) {
				if (otherPositions.Contains(pos - offsety) != true) {
					if (stepsleft == 1 && (pos - offsety) == oldposition) {
						//geen hond
					}else{
						tileList[pos - offsety].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canDown()) {
				if (otherPositions.Contains(pos + offsety) != true) {
					if (stepsleft == 1 && (pos + offsety) == oldposition) {
						//geen hond
					}else {
						tileList[pos + offsety].Draw(spriteBatch);
					}
				}
			}
		}

		public void Update(MouseState oldMouseState, MouseState mouseState, List<int> otherpos) {
			
			Rectangle up = new Rectangle((int)tileList[pos].position.X, (int)tileList[pos].position.Y - Game1.tileoffsety, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle down = new Rectangle((int)tileList[pos].position.X, (int)tileList[pos].position.Y + Game1.tileoffsety, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle left = new Rectangle((int)tileList[pos].position.X - (Game1.tileoffsetx), (int)tileList[pos].position.Y, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle right = new Rectangle((int)tileList[pos].position.X + (Game1.tileoffsetx), (int)tileList[pos].position.Y, Game1.tileoffsetx, Game1.tileoffsety);
			/*Console.WriteLine("down: " + down.ToString());
			Console.WriteLine("up: " + up.ToString());
			Console.WriteLine("left: " + left.ToString());
			Console.WriteLine("right: " + right.ToString());
			Console.WriteLine("mouse: " + mouseState.Position.ToString());*/
			if (tileList[pos].tile.type().Contains("entry")) {

			}
			if (up.Contains(mouseState.Position)
				&& tileList[pos].tile.canUp() == true
				&& oldMouseState.LeftButton == ButtonState.Released
				&& mouseState.LeftButton == ButtonState.Pressed
				&& otherpos.Contains(pos - Game1.tilesx) != true) {
				if ((pos - Game1.tilesx) == oldposition && stepsleft == 1) { }
				else {
					pos -= Game1.tilesx;
					if (tileList[pos].tile.type().Contains("highway")) {
						stepsleft -= 0.5;
					}
					else {
						stepsleft -= 1;
					}
				}
			}
			else if (down.Contains(mouseState.Position)
				&& tileList[pos].tile.canDown() == true
				&& oldMouseState.LeftButton == ButtonState.Released
				&& mouseState.LeftButton == ButtonState.Pressed
				&& otherpos.Contains(pos + Game1.tilesx) != true) {
				if ((pos + Game1.tilesx) == oldposition && stepsleft == 1) { }
				else {
					pos += Game1.tilesx;
					if (tileList[pos].tile.type().Contains("highway")) {
						stepsleft -= 0.5;
					}
					else {
						stepsleft -= 1;
					}
				}
			}
			else if (left.Contains(mouseState.Position)
				&& tileList[pos].tile.canLeft() == true
				&& oldMouseState.LeftButton == ButtonState.Released
				&& mouseState.LeftButton == ButtonState.Pressed
				&& otherpos.Contains(pos - 1) != true
				) {
				if ((pos - 1) == oldposition && stepsleft == 1) { } else { 
					pos -= 1;
					if (tileList[pos].tile.type().Contains("highway")) {
						stepsleft -= 0.5;
					}
					else {
						stepsleft -= 1;
					}
				}
			}
			else if (right.Contains(mouseState.Position) 
				&& tileList[pos].tile.canRight() == true 
				&& oldMouseState.LeftButton == ButtonState.Released 
				&& mouseState.LeftButton == ButtonState.Pressed 
				&& otherpos.Contains(pos + 1) != true) {
				if ((pos + 1) == oldposition && stepsleft == 1) { }
				else {
					pos += 1;
					if (tileList[pos].tile.type().Contains("highway")) {
						stepsleft -= 0.5;
					}
					else {
						stepsleft -= 1;
					}
				}
				
			}
			if (stepsleft <= 0) {
				if (tileList[pos].tile.type().Contains("coin")) {
					if (gun == false) {
						Console.WriteLine(tileList[pos].tile.returnExtra());
						if (tileList[pos].tile.returnExtra() == "True" && firstcoin != true) {
							firstcoin = true;
							Console.WriteLine("firstcoin recieved");
						}
						else if (secondcoin != true) {
							secondcoin = true;
							Console.WriteLine("secondcoin recieved");
						}
					}
				}
				if (tileList[pos].tile.type().Contains("gun") && firstcoin == true && secondcoin == true) {
					firstcoin = false;
					secondcoin = false;
					gun = true;
					Console.WriteLine("gun recieved");
				}
			}
			
			
		}
	}
}
