﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Background
{
    public class CastleSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int castleWidth = 80;
        private int castleHeight = 80;
        private int textureX = 0;
        private int textureY = 0;
        public CastleSprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, castleWidth, castleHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);
             
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
             
        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, castleWidth, castleHeight);
        }
    }
}
