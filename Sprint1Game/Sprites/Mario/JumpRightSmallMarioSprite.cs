﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites
{
    class JumpRightSmallMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.Y;

        public JumpRightSmallMarioSprite(Texture2D texture) : base(texture)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = TextureX * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
