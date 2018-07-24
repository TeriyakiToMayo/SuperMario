﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public abstract class MarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public int MarioWidth { get; set; } = MarioSpriteFactory.Instance.NormalMarioWidth;
        public int MarioHeight { get; set; } = MarioSpriteFactory.Instance.NormalMarioHeight;


        protected MarioSprite(Texture2D texture)
        {
            Texture = texture;
            SourceRectangle = new Rectangle(GameUtilities.Origin, GameUtilities.Origin, MarioWidth, MarioHeight);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            SourceRectangle = new Rectangle(SourceRectangle.X, SourceRectangle.Y + GameUtilities.SinglePixel, MarioWidth, MarioHeight);
            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
             
        }

        public virtual void Update()
        {
        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, MarioWidth * GameUtilities.SpriteSize, MarioHeight * GameUtilities.SpriteSize);
        }
    }
}
