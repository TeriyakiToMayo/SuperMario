using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Block
{
    class UndergroundCrackedBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int undergroundCrackedBlockWidth = 16;
        private int undergroundCrackedBlockHeight = 16;
        private int textureX = 16;
        private int textureY = 64;
        public UndergroundCrackedBlockSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, undergroundCrackedBlockWidth, undergroundCrackedBlockHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, undergroundCrackedBlockWidth, undergroundCrackedBlockHeight);
        }
    }
}
