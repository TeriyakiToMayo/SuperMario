﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Mario
{
    class RunningLeftStarSmallMarioSprite : MarioRunningStarSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.RunningLeftStarSmallMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.RunningLeftStarSmallMarioCord.Y;
        public RunningLeftStarSmallMarioSprite(Texture2D texture) : base(texture)
        {
            currentRunningFrame = totalRunningFrame - 1;
            runningFrameIncrement = 1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - currentRunningFrame) * MarioWidth;
            int y = (TextureY + currentFlashingFrame) * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
