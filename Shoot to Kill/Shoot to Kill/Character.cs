using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot_to_Kill {
	class Character {
		public Texture2D texture;
		private int pos;
		private List<DrawableTile> tileList;
    public bool alive;
		private int offsetx, offsety;
		public double stepsleft;
		private int oldposition;
		public bool firstcoin, secondcoin, gun;
    public string name;
		public Character(int startingpos, List<DrawableTile> tileList, Texture2D texture, int offsety, int offsetx) {
			this.texture = texture;
			this.pos = startingpos;
			setOldPos();
      alive = true;
			this.tileList = tileList;
			this.offsety = offsety;
			this.offsetx = offsetx;
			this.firstcoin = false;
			this.secondcoin = false;
			this.gun = false;
      name = Console.ReadLine();
		}
		public DrawableTile currentTile() {
			return tileList[pos];
		}
		public int currentPos() {
			return pos;
		}
    public void die() {
      alive = false;
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
						if (tileList[pos - 1].tile.type().Contains("truck")) {
							tileList[pos - 1].Draw(spriteBatch);
						}
					} else {
						tileList[pos - 1].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canRight()) {
				if (otherPositions.Contains(pos + 1) != true) {
					if (stepsleft == 1 && (pos + 1) == oldposition) {
						if (tileList[pos + 1].tile.type().Contains("truck")) {
							tileList[pos + 1].Draw(spriteBatch);
						}
					}	else {
						tileList[pos + 1].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canUp()) {
				if (otherPositions.Contains(pos - offsety) != true) {
					if (stepsleft == 1 && (pos - offsety) == oldposition) {
						if (tileList[pos - offsety].tile.type().Contains("truck")) {
							tileList[pos - offsety].Draw(spriteBatch);
						}
					}
					else{
						tileList[pos - offsety].Draw(spriteBatch);
					}
				}
			}
			if (currentTile().tile.canDown()) {
				if (otherPositions.Contains(pos + offsety) != true) {
					if (stepsleft == 1 && (pos + offsety) == oldposition) {
						if (tileList[pos + offsety].tile.type().Contains("truck")) {
							tileList[pos + offsety].Draw(spriteBatch);
						}
					}
					else {
						tileList[pos + offsety].Draw(spriteBatch);
					}
				}
			}
		}

    public void Shoot(List<Character> players) {
      List<Character> deadCharacters = new List<Character>();
      foreach (Character character in players) {
        if (character != this) {
          //UP;
          int _currentPos = pos;
          int max = 0;
          if ((_currentPos - offsetx) < max) {
            break;
          }
          else {
            if (tileList[_currentPos - offsetx].tile.type().Contains("bush") != true) {
              while (true) {
                if (character.pos == _currentPos) {
                  deadCharacters.Add(character);
                  break;
                }
                else if ((_currentPos - offsetx) < max) {
                  break;
                }
                else if (tileList[_currentPos - offsetx].tile.type().Contains("bush")) {
                  break;
                }
                else if (tileList[_currentPos].tile.canUp() || tileList[_currentPos - offsetx].tile.type().Contains("penetrate")) {
                  _currentPos -= offsetx;
                }
                else {
                  break;
                }
              }
            }else {
              if (character.pos == (_currentPos - offsetx)) {
                deadCharacters.Add(character);
              }
            }
          }
          //DOWN;
          _currentPos = pos;
          max = (offsetx * offsety);
          if ((_currentPos + offsetx) > max) {
            break;
          }
          else {
            if (tileList[_currentPos + offsetx].tile.type().Contains("bush") != true) {
              while (true) {
                if (character.pos == _currentPos) {
                  deadCharacters.Add(character);
                  break;
                }
                else if ((_currentPos + offsetx) > max) {
                  break;
                }
                else if (tileList[_currentPos + offsetx].tile.type().Contains("bush")) {
                  break;
                }
                else if (tileList[_currentPos].tile.canDown() || tileList[_currentPos + offsetx].tile.type().Contains("penetrate")) {
                  _currentPos += offsetx;
                }
                else {
                  break;
                }
              }
            }else {
              if (character.pos == (_currentPos + offsetx)) {
                deadCharacters.Add(character);
              }
            }
          }
          //LEFT;
          _currentPos = pos;
          max = 0;
          if ((_currentPos - 1) < max) {
            break;
          }
          else {
            if (tileList[_currentPos - 1].tile.type().Contains("bush") != true) {
              while (true) {
                if (character.pos == _currentPos) {
                  deadCharacters.Add(character);
                  break;
                }
                else if ((_currentPos - 1) > max) {
                  break;
                }
                else if (tileList[_currentPos - 1].tile.type().Contains("bush")) {
                  break;
                }
                else if (tileList[_currentPos].tile.canLeft() || tileList[_currentPos - 1].tile.type().Contains("penetrate")) {
                  _currentPos -= 1;
                }
                else {
                  break;
                }
              }
            }
            else {
              if (character.pos == (_currentPos - 1)) {
                deadCharacters.Add(character);
              }
            }
          }
          //RIGHT;
          _currentPos = pos;
          max = (offsetx * offsety);
          if ((_currentPos + 1) > max) {
            break;
          }
          else {
            if (tileList[_currentPos + 1].tile.type().Contains("bush") != true) {
              while (true) {
                if (character.pos == _currentPos) {
                  deadCharacters.Add(character);
                  break;
                }
                else if ((_currentPos + 1) > max) {
                  break;
                }
                else if (tileList[_currentPos + 1].tile.type().Contains("bush")) {
                  break;
                }
                else if (tileList[_currentPos].tile.canDown() || tileList[_currentPos + 1].tile.type().Contains("penetrate")) {
                  _currentPos += 1;
                }
                else {
                  break;
                }
              }
            }
            else {
              if (character.pos == (_currentPos + 1)) {
                deadCharacters.Add(character);
              }
            }
          }




          foreach (Character charter in deadCharacters) {
            charter.die();
          }
        }
      }
    }
		public void Update(MouseState oldMouseState, MouseState mouseState, List<int> otherpos, List<Character> players) {
			
			Rectangle up = new Rectangle((int)tileList[pos].position.X, (int)tileList[pos].position.Y - Game1.tileoffsety, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle down = new Rectangle((int)tileList[pos].position.X, (int)tileList[pos].position.Y + Game1.tileoffsety, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle left = new Rectangle((int)tileList[pos].position.X - (Game1.tileoffsetx), (int)tileList[pos].position.Y, Game1.tileoffsetx, Game1.tileoffsety);
			Rectangle right = new Rectangle((int)tileList[pos].position.X + (Game1.tileoffsetx), (int)tileList[pos].position.Y, Game1.tileoffsetx, Game1.tileoffsety);
			/*Console.WriteLine("down: " + down.ToString());
			Console.WriteLine("up: " + up.ToString());
			Console.WriteLine("left: " + left.ToString());
			Console.WriteLine("right: " + right.ToString());
			Console.WriteLine("mouse: " + mouseState.Position.ToString());*/
			if (up.Contains(mouseState.Position)
				&& tileList[pos].tile.canUp() == true
				&& oldMouseState.LeftButton == ButtonState.Released
				&& mouseState.LeftButton == ButtonState.Pressed
				&& otherpos.Contains(pos - Game1.tilesx) != true) {
				if ((pos - Game1.tilesx) == oldposition && stepsleft == 1) {
          if (tileList[pos - Game1.tilesx].tile.type().Contains("truck")) {
            pos -= Game1.tilesx;
            stepsleft -= 1;
          }
        }
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
				if ((pos + Game1.tilesx) == oldposition && stepsleft == 1) {
					if (tileList[pos + Game1.tilesx].tile.type().Contains("truck")) {
						pos += Game1.tilesx;
						stepsleft -= 1;
					}
				}
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
				if ((pos - 1) == oldposition && stepsleft == 1) {
					if (tileList[pos - 1].tile.type().Contains("truck")) {
						pos -= 1;
						stepsleft -= 1;
					}
				} else { 
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
        if ((pos + 1) == oldposition && stepsleft == 1) {
          if ((pos + 1) == oldposition && stepsleft == 1) {
            if (tileList[pos + 1].tile.type().Contains("truck")) {
              pos += 1;
              stepsleft -= 1;
            }
          }
        }
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
        foreach (Character player in players) {
          if (player != this) {
            if (player.currentPos() == currentPos() - 1 ||
                player.currentPos() == currentPos() + 1 ||
                player.currentPos() == currentPos() - offsetx ||
                player.currentPos() == currentPos() + offsetx) {
              player.gun = false;
            }
          }
        }
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
        if (gun == true) {
          Shoot(players);
        }

			}
			
			
		}
	}
}
