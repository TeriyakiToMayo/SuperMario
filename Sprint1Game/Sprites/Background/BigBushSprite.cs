﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Background
{
    public class BigBushSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int bigBushWidth = 64;
        private int bigBushHeight = 16;
        private int textureX = 352;
        private int textureY = 19;
        public BigBushSprite(Texture2D texture)
        {      
            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, bigBushWidth, bigBushHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);
             
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
             
        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, bigBushWidth, bigBushHeight);
        }
    }
}
