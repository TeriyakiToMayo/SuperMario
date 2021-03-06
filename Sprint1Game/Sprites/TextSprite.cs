﻿using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game.Sprites
{
    public class TextSprite : ITextSprite
    {
        public string Text { get; set; }

        public Texture2D Texture { get; set; } = null;
        private SpriteFont font;
        private Vector2 size;

        public TextSprite(SpriteFont font)
        {
            this.font = font;
            this.size = new Vector2(0, 0);
        }

        public TextSprite(SpriteFont font, string text)
        {
            this.font = font;
            this.Text = text;
            this.size = font.MeasureString(Text);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(font, Text, location, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            size = font.MeasureString(Text);
            return new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }

        public void Update()
        {
            size = font.MeasureString(Text);
        }
    }
}
