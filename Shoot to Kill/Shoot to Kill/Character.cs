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
		public int stepsleft;
		public Character(int startingpos, List<DrawableTile> tileList, Texture2D texture, int offsety, int offsetx) {
			this.texture = texture;
			this.pos = startingpos;
			this.tileList = tileList;
			this.offsety = offsety;
			this.offsetx = offsetx;
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
		public void Update(SpriteBatch spriteBatch) {
			spriteBatch.Begin();
			if (currentTile().tile.canLeft()) {
				tileList[pos - 1].Draw(spriteBatch);
			}
			if (currentTile().tile.canRight()) {
				tileList[pos + 1].Draw(spriteBatch);
			}
			if (currentTile().tile.canUp()) {
				tileList[pos - offsety].Draw(spriteBatch);
			}
			if (currentTile().tile.canDown()) {
				tileList[pos + offsety].Draw(spriteBatch);
			}
			spriteBatch.End();
		}
	}
}
